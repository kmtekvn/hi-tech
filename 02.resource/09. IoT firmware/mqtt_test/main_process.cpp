#include <string.h>
#include <Arduino.h>

#include "main_process.h"

#include "sensor.h"
#include "actuator.h"
#include "ultilities.h"
#include "mqtt_client.h"
#include "main_process.h"

#include "logger.h"

/* Timer related variables*/
unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 1000;

static char retFrameBuf[SENML_DOC_BUFFER_SIZE];
static sensorData_t sensorStruct;

// Function prototype: khai bao ngyen ham de cac ham phia tren co the goi duoc
void _mainMqttSubDataHandler(String revcStr);

void _mainCheckSendData(void);
void(* resetSoftware)(void) = 0;

void Main_InitHw(void)
{
    // Init uart debug hw
  logging_Setup();

  // Init actuator hw
  actuator_LEDInit();

  Sensor_Init();
}

void Main_InitLibs(void)
{
  Ultil_SenMLInit();

  Sensor_Init();
  logging_SendDebug("Init sensor DONE");

  MQTTClient_Init();
  logging_SendDebug("Init MQTT Client DONE");

  /* Register subscribe handler*/
  MQTTClient_RegiserDatCb(_mainMqttSubDataHandler);
}

void Main_ProcessLoop()
{
  MQTTClient_Loop();
  if (MQTTClient_IsConnected() ) {
    _mainCheckSendData();
  }
}


void _mainMqttSubDataHandler(String revcStr)
{
  if (revcStr == "reboot")
  {
     logging_SendDebug("Will rebooting...");
     delay(100);
     resetSoftware();
  }else
  {
     actuator_LEDChangeBrightness(revcStr.toInt());
  }
}

void _mainCheckSendData(void) 
{

  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) 
  {
      // Doc du lieu cam bien
       Sensor_collectData(&sensorStruct);
       logging_SendDebug("Collect sensor data DONE");
       
       // Tao frame data
      memset(retFrameBuf, 0x00, SENML_DOC_BUFFER_SIZE);
      Ultil_MakeSenMLFrame(&sensorStruct, retFrameBuf);
      logging_SendDebug("Created data frame DONE");

      MQTTClient_SendPubFrame(retFrameBuf);

      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}
