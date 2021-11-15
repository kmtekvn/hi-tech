#ifndef APP_CONFIG_H
#define APP_CONFIG_H

/* Define output */
#define   USER_LED_PIN           13 

/*TODO: command template: <LED CMD> <LED ID>,<LED STATE> "LED STATE" (0 -> 255) 
 Eg. cmd1: "led,13,255"
     cmd2: "led,5,0"
     cmd3: "led,13,100"
*/ 

#define  LED_CMD                   "led"  

#define  SENSOR_SAMPLING_PERIOD    100 //ms


#define  TOPIC_CMD               "/arduino/control"
#define  ESPLINK_PUBLISH_TOPIC   "/arduino/data"
#define  ESPLINK_SUB_TOPIC       TOPIC_CMD


#define  SENML_DEVICE_NAME        "iot_device"

#define  SHOW_DEBUG                 0  // Enable Debug

#if SHOW_DEBUG > 0
  #define  DEBUG_MSG(msg)          do { Serial.println(msg); } while(0);
#else 
  #define  DEBUG_MSG(msg)
#endif

#endif /* APP_CONFIG_H */
