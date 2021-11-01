/*TODO: include module header*/
#include "esplink_client.h" // Them vao file header tai folder local

#define LED_ON_CMD  "led_on"
#define TOPIC_CMD   "/arduino/control"

static int count = 0;
static uint32_t last;

void mqtt_app_command_handler(String topic, String payload);

void setup() {
  // Khoi tao cong Serial 
  Serial1.begin(115200); // Cong giao tiep ESP TX1, RX1
  Serial.begin(115200);  // Cong giao tiep PC
  
  Serial.println("EL-Client starting!"); // ln = line: xuong dong

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

void loop() {
  /* TODO: call esplink loop process */
  esplink_loop();
  
  // Example send data to MQTT broker
  if (esplink_is_connected() && (millis()-last) > 4000) {
    Serial.println("publishing");
    /*TODO: call publish function */
    esplink_pub_msg(count++);
    last = millis();
  }
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