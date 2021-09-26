#include "sensor.h"
#include "MAX30105.h" 
#include <movingAvg.h> 

MAX30105 particleSensor;
movingAvg tempSensor(10);                // define the moving average object

static sensorData_t sensorStruct;
static bool sensorAvailable = false;

void Sensor_Init(void)
{
  tempSensor.begin();
  // Initialize sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
    Serial.println("MAX30105 was not found. Please check wiring/power. ");
    return;
  }
  sensorAvailable = true;

  particleSensor.setup(); //Configure sensor. Use 25mA for LED drive

  particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
}


void Sensor_collectData(sensorData_t* userbuf)
{ 
  if (!sensorAvailable) { return; }
  
  int temperature = particleSensor.readTemperature()*10;
  int temperature_avg = tempSensor.reading(temperature);  

  if (userbuf != NULL) {
    userbuf->heartbeat =  temperature_avg;
    userbuf->temperature = temperature_avg;
  }
}
