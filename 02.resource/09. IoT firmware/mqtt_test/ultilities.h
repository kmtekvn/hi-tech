#ifndef UTILITIES_H_
#define UTILITIES_H_
#include "sensor.h"

void Ultil_SenMLInit(void);
void Ultil_MakeSenMLFrame(sensorData_t* sensorStructP,  char* retFrameP);

#endif /* UTILITIES_H_ */