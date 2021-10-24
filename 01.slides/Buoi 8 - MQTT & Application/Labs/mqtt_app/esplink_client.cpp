#include "esplink_client.h"

#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>

#include <Arduino.h> // for Serial1 & Serial symbol

#define ESPLINK_SYNC_TIMEOUT  10000UL  // 10 seconds

typedef void (*__data_process_func_t)(String, String); // Khai bao kieu du lieu con tro ham

static __data_process_func_t  __user_data_process_cb; // Tao bien co kieu du lieu function pointer

/* Declare function prototype */
void wifiCb(void* response);
void mqttConnected(void* response);
void mqttDisconnected(void* response);
void mqttData(void* response);
void mqttPublished(void* response);

// Initialize a connection to esp-link using the normal hardware serial port both for
// SLIP and for debug messages.
ELClient esp(&Serial1, &Serial); // Serial : default debug port

// Initialize CMD client (for GetTime)
ELClientCmd cmd(&esp);

// Initialize the MQTT client
ELClientMqtt mqtt(&esp);

static bool connected; /*static: khai bao cac bien chi dung trong file hien tai*/

bool esplink_is_connected()
{
  return connected;
}

bool esplink_sync_check()
{
  // Sync-up with esp-link, this is required at the start of any sketch and initializes the
  // callbacks to the wifi status change callback. The callback gets called with the initial
  // status right after Sync() below completes.
  esp.wifiCb.attach(wifiCb); // wifi status change callback, optional (delete if not desired)
  unsigned long first = millis();
  
  bool ok = false;
  do {
    if (millis() - first > ESPLINK_SYNC_TIMEOUT)
    {
      break;
    }
    ok = esp.Sync();      // sync up with esp-link, blocks for up to 2 seconds
    if (!ok) Serial.println("EL-Client sync failed!");
  } while(!ok);

   return ok;
}

void esplink_setup_mqtt()
{
  mqtt.connectedCb.attach(mqttConnected);
  mqtt.disconnectedCb.attach(mqttDisconnected);
  mqtt.publishedCb.attach(mqttPublished);
  mqtt.dataCb.attach(mqttData);
  mqtt.setup();

  //Serial.println("ARDUINO: setup mqtt lwt");
  //mqtt.lwt("/lwt", "offline", 0, 0); //or mqtt.lwt("/lwt", "offline");
}

void esplink_loop()
{
   esp.Process(); // Library loop, process data frame sent from ESP
}

void esplink_pub_msg(const char* msg)
{
    mqtt.publish("/esp-link/1", msg);
}

void esplink_data_call_register(void* func_ptr)
{
  __user_data_process_cb = (__data_process_func_t)func_ptr; /* casting function pointer */
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

// Callback when MQTT is connected
void mqttConnected(void* response) {
  Serial.println("MQTT connected!");
  mqtt.subscribe("/esp-link/1");
  mqtt.subscribe("/hello/world/#");

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

  __user_data_process_cb(topic, data); // Call user function indirectly via function pointer
}

void mqttPublished(void* response) {
  Serial.println("MQTT published");
}
