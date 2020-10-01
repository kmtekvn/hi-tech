#include <WiFiEsp.h>
#include <WiFiEspClient.h>
#include <WiFiEspUdp.h>
#include <PubSubClient.h>
#include <kpn_senml.h>

#define TEST_SKIP_WIFI   

typedef struct {
  unsigned char heartbeat;
  unsigned int  temperature;
} sensorData_t;

#define SENML_DOC_BUFFER_SIZE  120

SenMLPack doc("gateway");
SenMLPack dev1("dev1");

char retFrameBuf[SENML_DOC_BUFFER_SIZE];
sensorData_t sensorStruct;

IPAddress server(192, 168, 43, 241);

char ssid[] = "milo house";           // your network SSID (name)
char pass[] = "1234567890a";           // your network password
int status = WL_IDLE_STATUS;   // the Wifi radio's status

unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 1000;

// Initialize the Ethernet client object
WiFiEspClient espClient;

PubSubClient client(espClient);

void collectSensorData(sensorData_t* userbuf){
  if (userbuf != NULL) {
    userbuf->heartbeat = 60;
    userbuf->temperature = 35;
  }
}

String makeSenMLFrame(sensorData_t* sensorStructP, const char* retFrameP) {
   SenMLFloatRecord rec1(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, sensorStructP->temperature);
   dev1.add(&rec1);

   SenMLFloatRecord rec2(KPN_SENML_BREADTH, SENML_UNIT_BEATS, sensorStructP->heartbeat);
   dev1.add(&rec2);

//    doc.toJson(&Serial);
//    Serial.println();
 
  doc.toJson(retFrameP, SENML_DOC_BUFFER_SIZE);  
  Serial.println(retFrameP);
}

void checkAndSendingData() {
  sensorData_t data;
  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) {
       collectSensorData(&sensorStruct);
       memset(retFrameBuf, 0x00, SENML_DOC_BUFFER_SIZE);
       makeSenMLFrame(&sensorStruct, retFrameBuf);
       //client.publish("command","hello world");
      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}

void setup() {
  // initialize serial for debugging
  Serial.begin(115200);
  Serial1.begin(115200);

  senMLSetLogger(&Serial);
  doc.add(&dev1);
  
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

#if 1
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
    // Hien thi dia chi IP cua board
    Serial.print("My IP address:");
    Serial.print(espClient.getIPAddress());

    Serial.print("Attempting MQTT connection...");
    // Attempt to connect, just a name to identify the client
    if (client.connect("arduinoClient")) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish("command","hello world");
      // ... and resubscribe
      client.subscribe("presence");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}
 
