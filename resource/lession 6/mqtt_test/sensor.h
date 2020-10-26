#ifndef SENSOR_H_
#define SENSOR_H_

/* Custom data structure */
typedef struct {
  unsigned char heartbeat;
  unsigned int  temperature;
} sensorData_t;


void Sensor_Init(void);
void Sensor_collectData(sensorData_t* userbuf);

#endif /* SENSOR_H_ */