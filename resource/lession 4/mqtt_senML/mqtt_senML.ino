#include <WiFiEsp.h>
#include <WiFiEspClient.h>
#include <WiFiEspUdp.h>
#include <PubSubClient.h>
#include <kpn_senml.h>

//#define TEST_SKIP_WIFI   

      // TODO: move to outside
       const char* mqttMonitorTopic = "arduino/monitor";

          
typedef struct {
  unsigned char heartbeat;
  unsigned int  temperature;
} sensorData_t;

#define SENML_DOC_BUFFER_SIZE  120

SenMLPack doc("gateway");
SenMLPack dev1("dev1");

char retFrameBuf[SENML_DOC_BUFFER_SIZE];
sensorData_t sensorStruct;

IPAddress server(192, 168, 1, 5);
//#define server "test.mosquitto.org"

#if 1
char ssid[] = "milo house";           // your network SSID (name)
char pass[] = "1234567890a";           // your network password
#else
char ssid[] = "hitech";           // your network SSID (name)
char pass[] = "12345678";           // your network password
#endif

int status = WL_IDLE_STATUS;   // the Wifi radio's status

unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 5000;

sensorData_t data;
// Initialize the Ethernet client object
WiFiEspClient espClient;

PubSubClient client(espClient);

SenMLFloatRecord rec1(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, 0);
SenMLFloatRecord rec2(KPN_SENML_BREADTH, SENML_UNIT_BEATS, 0);

void collectSensorData(sensorData_t* userbuf){
  if (userbuf != NULL) {
    userbuf->heartbeat = 60;
    userbuf->temperature = 35;
  }
}

void makeSenMLFrame(sensorData_t* sensorStructP,  char* retFrameP) {
 rec1.set(sensorStructP->temperature);
 rec2.set(sensorStructP->heartbeat);
 doc.toJson(retFrameP, SENML_DOC_BUFFER_SIZE);  
}

void checkAndSendingData() {
  
  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) {
#if 0      
      // Doc du lieu cam bien
       collectSensorData(&sensorStruct);
      // Serial.println("Collect sensor data");
       
       // Tao frame data
       memset(retFrameBuf, 0x00, SENML_DOC_BUFFER_SIZE);
       makeSenMLFrame(&sensorStruct, retFrameBuf);
     //  Serial.println("Created data frame");
      // Serial.println(retFrameBuf);


       // Gui du lieu toi MQTT broker (PC)
      // strcpy(retFrameBuf, "[{\"bn\":\"gateway\"},{\"bn\":\"dev1\",\"n\":\"temperature\",\"u\":\"Cel\",\"v\":35.0},{\"n\":\"breadth\",\"u\":\"beats\",\"v\":60.0}]");
       
       client.publish(mqttMonitorTopic, retFrameBuf, strlen(retFrameBuf));
#endif
      client.publish(mqttMonitorTopic, "hello", 5);
      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}
// Tao macro  trong C
#define ESP_UART_BAUDRATE    (9600) // UL: unsigned long

void setup() {
  // initialize serial for debugging
  Serial.begin(115200); // Serial log
  Serial1.begin(ESP_UART_BAUDRATE); // Cong giao tiep ESP

  senMLSetLogger(&Serial);
  doc.add(&dev1);
  dev1.add(&rec1);
  dev1.add(&rec2);
   
#ifndef TEST_SKIP_WIFI
  // initialize ESP module
  WiFi.init(&Serial1);
  
  // check for the presence of the shield
  if (WiFi.status() == WL_NO_SHIELD) {
    Serial.println("WiFi shield not present");
    // don't continue
    while (true);
  }
  // attempt to connect to WiFi network
  while ( status != WL_CONNECTED) {
    Serial.print("Attempting to connect to WPA SSID: ");
    Serial.println(ssid);
    // Connect to WPA/WPA2 network
    status = WiFi.begin(ssid, pass);
  }

  // you're connected now, so print out the data
  Serial.println("You're connected to the network");

  //connect to MQTT server
  client.setSocketTimeout(60);
  client.setServer(server, 1883);
  client.setCallback(callback);
#endif  
}

//print any message received for subscribed topic
void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i=0;i<length;i++) {
    Serial.print((char)payload[i]);
  }
  Serial.println();
}
// #if 1
#ifdef TEST_SKIP_WIFI
void loop(){
  checkAndSendingData();
}
#else
void loop() {
  // put your main code here, to run repeatedly:
  if (!client.connected()) {
    reconnect();
  }else {
    checkAndSendingData();
  }
  client.loop();
}
#endif
void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) {
    client.disconnect();
    delay(1000);
    Serial.print("Attempting MQTT connection...");
    // Attempt to connect, just a name to identify the client
    if (client.connect("arduinoClient")) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish("command","hello world");
      // ... and resubscribe
      client.subscribe("arduino/control");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(2000);
    }
  }
}
 
