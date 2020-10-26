#include <ELClientMqtt.h>
#include <ELClientCmd.h>


#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>

#include "logger.h"

// SLIP and for debug messages.
ELClient esp(&Serial1, &Serial);

// Initialize CMD client (for GetTime)
ELClientCmd cmd(&esp);

// Initialize the MQTT client
ELClientMqtt mqtt(&esp);

bool connected;
user_func 	__main_callback_invoke;

void mqtt_client_setup(void);

void MQTT_ClientInit(void)
{  
  bool ok;
  esp.wifiCb.attach(wifiCb); // wifi status change callback, optional (delete if not desired)
  
  do 
  {
    ok = esp.Sync();      // sync up with esp-link, blocks for up to 2 seconds
    if (!ok) { ultiLogging_Debug("EL-Client sync failed!"); }
  } while(!ok);


  // Set-up callbacks for events and initialize with es-link.
  mqtt_client_setup();

  ultiLogging_Debug("EL-MQTT ready");
}

void MQTTClient_SendPubFrame(const char* frame)
{
	mqtt.publish(MQTT_MONITOR_TOPIC, frame);
}

//================================CALL BACKS=====================
// Callback made from esp-link to notify of wifi status changes
// Here we just print something out for grins
void wifiCb(void* response) 
{
  ELClientResponse *res = (ELClientResponse*)response;
  if (res->argc() == 1) {
    uint8_t status;
    res->popArg(&status, 1);

    if(status == STATION_GOT_IP) {
      ultiLogging_Debug("WIFI CONNECTED");
    } else {
      ultiLogging_Debug("WIFI NOT READY: ");
      ultiLogging_Debug(status);
    }
  }
}

void mqttPublished(void* response) 
{
  logging_SendDebug("MQTT published");
}

void MQTTClient_RegiserDatCb(user_func func)
{
	if (func)
	{
		__main_callback_invoke = func;
	}
}

// Callback when an MQTT message arrives for one of our subscriptions
void mqttData(void* response) 
{
  ELClientResponse *res = (ELClientResponse *)response;

  logging_SendDebug("Received: topic=");
  String topic = res->popString();
  logging_SendDebug(topic);

  logging_SendDebug("data=");
  String data = res->popString();
  logging_SendDebug(data);

  if (data == "ON" || data == "OFF") 
  {
   if (__main_callback_invoke) { __main_callback_invoke(data);}
  }
}

// Callback when MQTT is connected
void mqttConnected(void* response) {
  logging_SendDebug("MQTT connected!");
  mqtt.subscribe(MQTT_CONTROL_TOPIC);
  connected = true;
}

// Callback when MQTT is disconnected
void mqttDisconnected(void* response) {
  logging_SendDebug("MQTT disconnected");
  connected = false;
}



void mqtt_client_setup(void)
{
  mqtt.connectedCb.attach(mqttConnected);
  mqtt.disconnectedCb.attach(mqttDisconnected);
  mqtt.publishedCb.attach(mqttPublished);
  mqtt.dataCb.attach(mqttData);
  mqtt.setup();
  ultiLogging_Debug("EL-Client starting!");
}