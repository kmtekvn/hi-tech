#include <Wire.h>

#include <movingAvg.h>                  // https://github.com/JChristensen/movingAvg
#include "MAX30105.h"  //Get it here: http://librarymanager/All#SparkFun_MAX30105
#include "heartRate.h"

#include "app_config.h"
#include "sensor_drv.h"

#define MAX3015_PART_ID   0x15

#ifndef SENSOR_SAMPLING_PERIOD
  #define  SENSOR_SAMPLING_PERIOD    100 //ms
#endif /* SENSOR_SAMPLING_PERIOD */

MAX30105  particleSensor;
movingAvg room_temperature(10);  // define the moving average object 10 = 10 samples

uint8_t  sensor_rev = 0;
uint8_t  sensor_part_id = 0;
float    beatsPerMinute = 0;
float    beatAvg = 0;
long     lastBeat = 0; //Time at which the last beat occurred

const    byte RATE_SIZE = 4; //Increase this for more averaging. 4 is good.
byte     rates[RATE_SIZE]; //Array of heart rates
byte     rateSpot = 0;

long     last_sensor_ts = 0;

SensorData_t  sensor_data;

bool sensor_check_id()
{
  sensor_rev= particleSensor.getRevisionID();
  sensor_part_id = particleSensor.readPartID();
  
  DEBUG_MSG("Sensor Revision ID = ");
  DEBUG_MSG(sensor_rev);
  DEBUG_MSG("Sensor Part ID =");
  DEBUG_MSG(sensor_part_id);

  return ( MAX3015_PART_ID == sensor_part_id );
}


void sensor_drv_setup()
{
  // Initialize sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
  
    DEBUG_MSG("MAX30105 was not found. Please check wiring/power. ");
    while (1);
  }
  
  if ( sensor_check_id() == false )
  {
     DEBUG_MSG("MAX30105 Wrong part ID ");
  }else 
  {
    DEBUG_MSG("Check Part ID OK!! ");
  }

  //The LEDs are very low power and won't affect the temp reading much but
  //you may want to turn off the LEDs to avoid any local heating
  particleSensor.setup(); //Configure sensor with default settings

  // Setup LED
  particleSensor.setPulseAmplitudeRed(0x0A); //Turn Red LED to low to indicate sensor is running
  particleSensor.setPulseAmplitudeGreen(0); //Turn off Green LED

  particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
  
  room_temperature.begin();
}

void _sensor_drv_update_temperature(float val)
{
  sensor_data.temperature = val*10; // 30.3 = 303
}

void _sensor_drv_update_heartbeat(float val)
{
  sensor_data.heartbeat = (unsigned char)val;
}

/**=============================TEMPEATURE=====================**/
/* Read single measurement */
float sensor_drv_get_temp()
{
  float temperature = particleSensor.readTemperature();
  float filtered_val = room_temperature.reading(temperature);
  
  DEBUG_MSG(temperature);
  DEBUG_MSG(",");
  DEBUG_MSG(filtered_val);

  _sensor_drv_update_temperature(filtered_val);
  
  return filtered_val;
}

/**=============================HEART RATE MEASUREMENT=====================**/
float sensor_drv_get_heartbeat_single()
{
  long irValue = particleSensor.getIR(); // Get raw measurement

  if (checkForBeat(irValue) == true)
  {
    //We sensed a beat!
    long delta = millis() - lastBeat;
    lastBeat = millis();

    beatsPerMinute = 60 / (delta / 1000.0);

    if (beatsPerMinute < 255 && beatsPerMinute > 20)
    {
      rates[rateSpot++] = (byte)beatsPerMinute; //Store this reading in the array
      rateSpot %= RATE_SIZE; //Wrap variable

      //Take average of readings
      beatAvg = 0;
      for (byte x = 0 ; x < RATE_SIZE ; x++)
        beatAvg += rates[x];
      beatAvg /= RATE_SIZE;
    }
    
    _sensor_drv_update_heartbeat(beatsPerMinute);
  }
}

float sensor_drv_get_hearbeat()
{
 return beatsPerMinute; 
}

void sensor_drv_get_all_data(SensorData_t* user_ptr)
{
  if ( user_ptr != NULL)
  {
    memcpy(user_ptr, &sensor_data,sizeof(SensorData_t) );
  }
}


void sensor_drv_processing()
{
  if ( (millis() - last_sensor_ts) >  SENSOR_SAMPLING_PERIOD )
  {
    sensor_drv_get_temp();
    sensor_drv_get_heartbeat_single();
    last_sensor_ts = millis();
  }
 
}
