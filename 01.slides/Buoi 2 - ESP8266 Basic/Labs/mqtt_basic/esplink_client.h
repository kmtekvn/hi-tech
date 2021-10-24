#ifndef ESPLINK_CLIENT
#define ESPLINK_CLIENT /*#ifndef &  #define => avoid duplicate definition when includes nested header files */


void esplink_loop();
bool esplink_sync_check();
void esplink_setup_mqtt();
bool esplink_is_connected();
void esplink_pub_msg(unsigned long val);
void esplink_data_call_register(void* func_ptr);


#endif /* ESPLINK_CLIENT */
