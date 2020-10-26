#ifndef MQTT_CLIENT_H_
#define MQTT_CLIENT_H_

typedef  (*user_func)(const char* msg);

void MQTTClient_Init(void);
void MQTTClient_RegiserDatCb(user_func func);
void MQTTClient_SendPubFrame(const char* frame);

#endif /* MQTT_CLIENT_H_ */