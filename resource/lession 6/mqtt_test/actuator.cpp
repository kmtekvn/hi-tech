#include "actuator.h"

void actuator_LEDInit(void)
{
  pinMode(LED_BUILTIN, OUTPUT);
}

void actuator_LEDChangeState(bool state)
{
  digitalWrite(LED_BUILTIN, state);
}