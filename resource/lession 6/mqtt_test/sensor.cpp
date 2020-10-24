#include "sensor.h"
#include <movingAvg.h>            
#include "MAX30105.h"  //Get it here: http://librarymanager/All#SparkFun_MAX30105

MAX30105 particleSensor;
movingAvg tempSensor(10);                // define the moving average object
static sensorData_t sensorStruct;


void collectSensorData(sensorData_t* userbuf)
{ int temperature = particleSensor.readTemperature()*10;
  int temperature_avg = tempSensor.reading(temperature);  

  if (userbuf != NULL) {
    userbuf->heartbeat = 60;
    userbuf->temperature = temperature_avg;
  }
}

void sensorInit(void)
{
 tempSensor.begin();
  // Initialize sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
    Serial.println("MAX30105 was not found. Please check wiring/power. ");
    while (1);
  }
  particleSensor.setup(); //Configure sensor. Use 25mA for LED drive

  particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
}