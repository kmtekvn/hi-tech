#include <Arduino.h>

#include "esplink_client.h"
#include "senml_encode.h"
#include "sensor_drv.h"
#include "actuator.h"
#include "app_config.h"

#define MAX_SENML_STRING_BUFFER_LEN       128
static char buffer[MAX_SENML_STRING_BUFFER_LEN];
static int temperature = 32;
static float heatbeat = 0;

static uint32_t last;


void setup()
{
  // Khoi tao cong Serial 
  //Serial1.begin(115200); // Cong giao tiep ESP TX1, RX1 - chi co tren arduino mega
  Serial.begin(115200);  // Cong giao tiep PC

  // Khoi tao sensor driver
  sensor_drv_setup();

 // Khoi tao output driver
 actuator_setup();
 
  // Khoi tao message encoder library
  senml_encode_init();

 /*TODO: call esplink sync function */
  if ( esplink_sync_check() )
  {
    Serial.println("EL-Client synced!");
  
    // Set-up callbacks for events and initialize with es-link.
    /*TODO: call esplink setup function */
    esplink_setup_mqtt();
    esplink_data_call_register(mqtt_app_command_handler);
    Serial.println("EL-MQTT ready");
  }else {
    Serial.println("EL-MQTT sync timeout");
  }  
  
}


void loop()
{
  SensorData_t data;
  
  // Example send data to MQTT broker
  if (esplink_is_connected() && (millis()-last) > 4000) 
  {
    Serial.println("Read sensor data ");
    sensor_drv_get_all_data(&data);
    /*
    DEBUG_MSG("SENSOR DATA");
    DEBUG_MSG(data.temperature);
    DEBUG_MSG(data.heartbeat);
    */
    Serial.println("publishing");
    /*TODO: call publish function */
    senml_encode_add_record(SENML_REC_TYPE_TEMP, data.temperature);
    senml_encoder_get_string(buffer, MAX_SENML_STRING_BUFFER_LEN);
    
    esplink_pub_msg(buffer);
    last = millis();
  }
    
   esplink_loop();
   sensor_drv_processing();
}

void mqtt_app_command_handler(String topic, String payload)
{
  if ( topic == TOPIC_CMD ) 
  {
   /* if (payload == LED_ON_CMD)
    {
      actuator_change_led_state(LED_ON);
    }else if (payload == LED_OFF_CMD){
      actuator_change_led_state(LED_OFF);
    } else if (payload == LED_PWM_CMD){
      actuator_change_led_brightness(0); // TODO: parse PWM value
    }*/
  }
}
