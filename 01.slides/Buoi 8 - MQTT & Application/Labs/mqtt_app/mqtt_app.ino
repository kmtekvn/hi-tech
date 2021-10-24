#include "esplink_client.h"
#include "senml_encode.h"

#define MAX_SENML_STRING_BUFFER_LEN       128
static char buffer[MAX_SENML_STRING_BUFFER_LEN];
static int temperature = 32;
static uint32_t last;

#define LED_ON_CMD  "led_on"
#define TOPIC_CMD   "/arduino/control"


void setup()
{
  // Khoi tao cong Serial 
  Serial1.begin(115200); // Cong giao tiep ESP TX1, RX1
  Serial.begin(115200);  // Cong giao tiep PC
  
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
  // Example send data to MQTT broker
  if (esplink_is_connected() && (millis()-last) > 4000) {
    Serial.println("publishing");
    /*TODO: call publish function */
    senml_encode_add_record(SENML_REC_TYPE_TEMP, temperature);
    senml_encoder_get_string(buffer, MAX_SENML_STRING_BUFFER_LEN);
    
    esplink_pub_msg(buffer);
    last = millis();
  }
    
   esplink_loop();
}



void mqtt_app_command_handler(String topic, String payload)
{
  if ( topic == TOPIC_CMD ) 
  {
    if (payload == LED_ON_CMD)
    {
      digitalWrite(13, HIGH);
    }else {
      digitalWrite(13, LOW);
    }
  }
}
