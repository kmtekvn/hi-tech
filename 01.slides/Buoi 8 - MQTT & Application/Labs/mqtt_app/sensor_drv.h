#ifndef SENSOR_DRV_H_ /*  Avoid dupplicated definition */
#define SENSOR_DRV_H_

// Khai bao kieu du lieu struct chua gia tri cam bien
typedef struct {
  unsigned int  temperature;
  unsigned int  heartbeat;
} SensorData_t;

void  sensor_drv_setup();
float sensor_drv_get_temp();
float sensor_drv_get_temp_multi();
float sensor_drv_get_hearbeat();
void  sensor_drv_processing();


void sensor_drv_get_all_data(SensorData_t* user_ptr);

#endif /* SENSOR_DRV_H_ */
