#ifndef SENSOR_H_
#define SENSOR_H_

/* Custom data structure */
typedef struct {
  unsigned char heartbeat;
  unsigned int  temperature;
} sensorData_t;


void sensorInit(void);
void collectSensorData(sensorData_t* userbuf);

#endif /* SENSOR_H_ */