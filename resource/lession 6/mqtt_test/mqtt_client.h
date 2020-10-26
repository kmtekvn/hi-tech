#ifndef MQTT_CLIENT_H_
#define MQTT_CLIENT_H_

typedef  void (*user_func)(String);

void MQTTClient_Init(void);
void MQTTClient_RegiserDatCb(user_func func);
void MQTTClient_SendPubFrame(const char* frame);

bool MQTTClient_IsConnected(void);
bool MQTTClient_Loop(void);
#endif /* MQTT_CLIENT_H_ */