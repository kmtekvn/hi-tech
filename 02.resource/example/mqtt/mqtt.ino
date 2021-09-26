/**
 * Simple example to demo the esp-link MQTT client
 */

#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>
#include <kpn_senml.h>
#include "sensor.h"

SenMLPack doc("temperature_sensor");

// Initialize a connection to esp-link using the normal hardware serial port both for
// SLIP and for debug messages.
ELClient esp(&Serial, &Serial);

// Initialize CMD client (for GetTime)
ELClientCmd cmd(&esp);

// Initialize the MQTT client
ELClientMqtt mqtt(&esp);

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
  mqtt.subscribe("/esp-link/1");
  mqtt.subscribe("/hello/world/#");
  //mqtt.subscribe("/esp-link/2", 1);
  //mqtt.publish("/esp-link/0", "test1");
  connected = true;
}

// Callback when MQTT is disconnected
void mqttDisconnected(void* response) {
  Serial.println("MQTT disconnected");
  connected = false;
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
}

void mqttPublished(void* response) {
  Serial.println("MQTT published");
}

void setup() {
  
  // Setup cam bien
  sensor_setup();
  
  Serial.begin(115200);
  Serial1.begin(115200);
  senMLSetLogger(&Serial);
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

  //Serial.println("ARDUINO: setup mqtt lwt");
  //mqtt.lwt("/lwt", "offline", 0, 0); //or mqtt.lwt("/lwt", "offline");

  Serial.println("EL-MQTT ready");
}

static int count;
static uint32_t last;

void build_string_data(char* user_buf, int buf_size, float data)
{
  #if 0
  int convert_data = data * 10;
  
  sprintf(user_buf, "%d", convert_data);
  #endif 
  
  SenMLFloatRecord rec(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, data);
  doc.add(&rec);                       
  doc.toJson(user_buf, buf_size);                      
}

char buf[128];

void loop() {
  esp.Process();

  if (connected && (millis()-last) > 4000) {
    Serial.println("publishing");
   

    itoa(count++, buf, 10);
    mqtt.publish("/esp-link/1", buf);

    itoa(count+99, buf, 10);
    mqtt.publish("/hello/world/arduino", buf);

    // Gui gia tri cam bien
    float temp_value = sensor_process();
    
    memset(buf, sizeof(buf), 0x00);
    build_string_data(buf, sizeof(buf), temp_value);
    Serial.println(buf);
    
    mqtt.publish("/sensor/data", buf);
    
    uint32_t t = cmd.GetTime();
    Serial.print("Time: "); Serial.println(t);

    last = millis();
  }
}
