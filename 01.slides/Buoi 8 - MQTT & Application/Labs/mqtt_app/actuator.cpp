#include <Arduino.h>
#include "actuator.h"

#include "app_config.h"

#ifndef USER_LED_PIN
  #define   USER_LED_PIN       13    // Macro dinh nghia chan IO
#endif  

void actuator_setup()
{
  pinMode(USER_LED_PIN, OUTPUT);
}

void actuator_change_led_state (bool state)
{
  digitalWrite(USER_LED_PIN, state);
}

void actuator_change_led_brightness (unsigned int pwm)
{
  analogWrite(USER_LED_PIN, pwm); // pwm :  0 - 255
}
