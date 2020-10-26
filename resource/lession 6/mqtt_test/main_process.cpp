#include "main_process.h"

#include "sensor.h"
#include "actuator.h"
#include "ultilities.h"
#include "mqtt_client.h"
#include "main_process.h"

/* Timer related variables*/
unsigned long previousMillis  = 0;
unsigned long currentMillis   = 0;
int interval = 1000;

static char retFrameBuf[SENML_DOC_BUFFER_SIZE];

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

  networking_setup();
  ultiLogging_Debug(" Init EL-Client Done");

  sensorInit();
  ultiLogging_Debug("Init sensor DONE");

  MQTT_ClientInit();
  ultiLogging_Debug("Init MQTT Client DONE");

  /* Register subscribe handler*/
  MQTTClient_RegiserDatCb(_mainMqttSubDataHandler);
  
}

void Main_ProcessLoop()
{
  esp.Process();
  if (connected ) {
    _mainCheckSendData();
  }
}


void _mainMqttSubDataHandler(const char* data)
{
  if (data == "ON") {
    actuator_LEDChangeState(true);
  }else if (data == "OFF") {
    actuator_LEDChangeState(false);
  }
}

void _mainCheckSendData() 
{
  currentMillis = millis();
  
  // check to see if the interval time is passed. 
  if (currentMillis - previousMillis >= interval == true ) 
  {
      // Doc du lieu cam bien
       Ultil_MakeSenMLFrame(&sensorStruct);
       ultiLogging_Debug("Collect sensor data DONE");
       
       // Tao frame data
       memset(retFrameBuf, 0x00, SENML_DOC_BUFFER_SIZE);
       makeSenMLFrame(&sensorStruct, retFrameBuf);
      ultiLogging_Debug("Created data frame DONE");

      MQTTClient_SendPubFrame(retFrameBuf);

      // save the time when we displayed the string for the last time
      previousMillis = currentMillis;
  }
}
