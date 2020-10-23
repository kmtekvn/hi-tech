/* EL Library */
#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>

/* SenML format library */
#include <kpn_senml.h>

#include "sensor.h"

static sensorData_t sensorStruct;

#define SENML_DOC_BUFFER_SIZE  120

const char* mqttMonitorPubTopic = "arduino/monitor";
const char* mqttControlSubTopic = "arduino/control";
static char retFrameBuf[SENML_DOC_BUFFER_SIZE];

unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 1000;

SenMLPack doc("gateway");
SenMLPack dev1("dev1");

SenMLFloatRecord rec1(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, 0);
SenMLFloatRecord rec2(KPN_SENML_BREADTH, SENML_UNIT_BEATS, 0);


// Initialize a connection to esp-link using the normal hardware serial port both for
// SLIP and for debug messages.
ELClient esp(&Serial1, &Serial);

// Initialize CMD client (for GetTime)
ELClientCmd cmd(&esp);

// Initialize the MQTT client
ELClientMqtt mqtt(&esp);


void makeSenMLFrame(sensorData_t* sensorStructP,  char* retFrameP) {
 rec1.set(sensorStructP->temperature);
 rec2.set(sensorStructP->heartbeat);
 doc.toJson(retFrameP, SENML_DOC_BUFFER_SIZE);  
}

void checkAndSendingData() {
  
  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) {
      // Doc du lieu cam bien
       collectSensorData(&sensorStruct);
       Serial.println("Collect sensor data DONE");
       
       // Tao frame data
       memset(retFrameBuf, 0x00, SENML_DOC_BUFFER_SIZE);
       makeSenMLFrame(&sensorStruct, retFrameBuf);
      Serial.println("Created data frame DONE");

      mqtt.publish(mqttMonitorPubTopic, retFrameBuf);

      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}
// Callback made from esp-link to notify of wifi status changes
// Here we just print something out for grins
void wifiCb(void* response) {
  ELClientResponse *res = (ELClientResponse*)response;
  if (res->argc() == 1) {
    uint8_t status;
    res->popArg(&status, 1);

    if(status == STATION_GOT_IP) {
      Serial.println("WIFI CONNECTED");
    } else {
      Serial.print("WIFI NOT READY: ");
      Serial.println(status);
    }
  }
}

bool connected;

// Callback when MQTT is connected
void mqttConnected(void* response) {
  Serial.println("MQTT connected!");
  mqtt.subscribe(mqttControlSubTopic);
  connected = true;
}

// Callback when MQTT is disconnected
void mqttDisconnected(void* response) {
  Serial.println("MQTT disconnected");
  connected = false;
}

void ChangeLEDStatus(bool state){
  digitalWrite(LED_BUILTIN, state);
}

// Callback when an MQTT message arrives for one of our subscriptions
void mqttData(void* response) {
  ELClientResponse *res = (ELClientResponse *)response;

  Serial.print("Received: topic=");
  String topic = res->popString();
  Serial.println(topic);

  Serial.print("data=");
  String data = res->popString();
  Serial.println(data);

  if (data == "ON") {
    ChangeLEDStatus(true);
  }else if (data == "OFF") {
    ChangeLEDStatus(false);
  }
}

void mqttPublished(void* response) {
  Serial.println("MQTT published");
}

void setup() {
  pinMode(LED_BUILTIN, OUTPUT);

  Serial.begin(115200);
  Serial1.begin(115200);

  senMLSetLogger(&Serial);
  doc.add(&dev1);
  dev1.add(&rec1);
  dev1.add(&rec2);

  Serial.println("EL-Client starting!");

  // Sync-up with esp-link, this is required at the start of any sketch and initializes the
  // callbacks to the wifi status change callback. The callback gets called with the initial
  // status right after Sync() below completes.
  esp.wifiCb.attach(wifiCb); // wifi status change callback, optional (delete if not desired)
  bool ok;
  do {
    ok = esp.Sync();      // sync up with esp-link, blocks for up to 2 seconds
    if (!ok) Serial.println("EL-Client sync failed!");
  } while(!ok);
  Serial.println("EL-Client synced!");

  // Set-up callbacks for events and initialize with es-link.
  mqtt.connectedCb.attach(mqttConnected);
  mqtt.disconnectedCb.attach(mqttDisconnected);
  mqtt.publishedCb.attach(mqttPublished);
  mqtt.dataCb.attach(mqttData);
  mqtt.setup();

  Serial.println("Init sensor");
  sensorInit();

  Serial.println("EL-MQTT ready");
}

void loop() {
  esp.Process();
  if (connected ) {
    checkAndSendingData();
  }
}
