#include <WiFiEsp.h>
#include <WiFiEspClient.h>
#include <WiFiEspUdp.h>
#include <PubSubClient.h>

IPAddress server(192, 168, 43, 241);

char ssid[] = "Mlem Mlem";           // your network SSID (name)
char pass[] = "1234567891";           // your network password
int status = WL_IDLE_STATUS;   // the Wifi radio's status


unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 1000;

// Initialize the Ethernet client object
WiFiEspClient espClient;

PubSubClient client(espClient);

void checkAndSendingData() {
  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) {
       client.publish("command","hello world");
      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}

void setup() {
  // initialize serial for debugging
  Serial.begin(115200);
  Serial1.begin(115200);
  
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

void loop() {
  // put your main code here, to run repeatedly:
  if (!client.connected()) {
    reconnect();
  }else {
    checkAndSendingData();
  }
  client.loop();
 
}

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
 
