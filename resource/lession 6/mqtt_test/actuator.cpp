#include <Arduino.h>
#include "actuator.h"


#define   USER_LED_PIN    13

void actuator_LEDInit(void)
{
  pinMode(USER_LED_PIN, OUTPUT);
}

void actuator_LEDChangeState(bool state)
{
  digitalWrite(USER_LED_PIN, state);
}