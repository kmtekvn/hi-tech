#include <movingAvg.h>                  // https://github.com/JChristensen/movingAvg
#include "MAX30105.h"  //Get it here: http://librarymanager/All#SparkFun_MAX30105
#include "sensor.h"

MAX30105 particleSensor;
movingAvg temperatureSensor(10);    

   // Sensor group
void sensor_setup()
{
	// 1. Khoi tao bo filter moving average
  temperatureSensor.begin();
  
    //2. Initialize MAX301505 sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
    Serial.println("MAX30105 was not found. Please check wiring/power. ");
    while (1);
  }
   particleSensor.setup(0); //Configure sensor. Turn off LEDs
   particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
}
float sensor_process()
{
  float temperature = particleSensor.readTemperature();
  float avgTemp = temperatureSensor.reading(temperature); 

  return avgTemp;
}
