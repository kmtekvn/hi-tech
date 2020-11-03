#ifndef ACTUATOR_H_
#define ACTUATOR_H_

void actuator_LEDInit(void);
void actuator_LEDChangeState(bool state);

void actuator_LEDChangeBrightness(int fadeValue);

#endif /* ACTUATOR_H_ */