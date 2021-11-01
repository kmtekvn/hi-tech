#include "sensor_drv.h"

void setup()
{
  Serial.begin(9600);
  Serial.println(" SENSOR Driver Example");
  sensor_drv_setup();
}

void loop()
{
  Serial.println( sensor_drv_get_temp() );
  delay(50);
}
