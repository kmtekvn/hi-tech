#ifndef ACTUATOR_H_
#define ACTUATOR_H_ 

typedef enum {
  LED_ON = 0x00,
  LED_OFF,
} LED_State_Enum_t;

void actuator_setup();
void actuator_change_led_state (bool state);
void actuator_change_led_brightness (unsigned int pwm);

#endif /* ACTUATOR_H_ */
