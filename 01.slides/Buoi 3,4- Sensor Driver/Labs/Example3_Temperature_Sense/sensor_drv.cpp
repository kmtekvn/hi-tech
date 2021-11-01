#include <Wire.h>

#include <movingAvg.h>                  // https://github.com/JChristensen/movingAvg
#include "MAX30105.h"  //Get it here: http://librarymanager/All#SparkFun_MAX30105

#define MAX3015_PART_ID   0x15

#define SHOW_DEBUG       0  // Enable Debug

MAX30105  particleSensor;
movingAvg room_temperature(10);  // define the moving average object 10 = 10 samples

uint8_t  sensor_rev = 0;
uint8_t  sensor_part_id = 0;

bool sensor_check_id()
{
  sensor_rev= particleSensor.getRevisionID();
  sensor_part_id = particleSensor.readPartID();
  
#if SHOW_DEBUG
  Serial.print("Sensor Revision ID = ");
  Serial.println(sensor_rev);
  Serial.print("Sensor Part ID =");
  Serial.println(sensor_part_id);
#endif

  return ( MAX3015_PART_ID == sensor_part_id );
}


void sensor_drv_setup()
{
  // Initialize sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
  
    Serial.println("MAX30105 was not found. Please check wiring/power. ");
    while (1);
  }
#if SHOW_DEBUG
  if ( sensor_check_id() == false )
  {
     Serial.println("MAX30105 Wrong part ID ");
  }else 
  {
    Serial.println("Check Part ID OK!! ");
  }
#endif

  //The LEDs are very low power and won't affect the temp reading much but
  //you may want to turn off the LEDs to avoid any local heating
  particleSensor.setup(0); //Configure sensor. Turn off LEDs
  //particleSensor.setup(); //Configure sensor. Use 25mA for LED drive

  particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
  
  room_temperature.begin();
}

float sensor_drv_get_temp()
{
  float temperature = particleSensor.readTemperature();
  float filtered_val = room_temperature.reading(temperature);
#if SHOW_DEBUG  
  Serial.print(temperature, 4);
  Serial.print(",");
  Serial.print(filtered_val, 4);
#endif
  return filtered_val;
}
