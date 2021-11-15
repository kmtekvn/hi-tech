#ifndef SENML_ENCODE
#define SENML_ENCODE

#ifndef SENML_DEVICE_NAME
  #define SENML_DEVICE_NAME  "arduino"
#endif  /* SENML_DEVICE_NAME */

enum {
  SENML_REC_TYPE_TEMP = 0x00,
  SENML_REC_TYPE_HUM,
} SensMLRecType_t;

void senml_encode_init();
void senml_encode_add_record(unsigned char rec_type, int val);
void senml_encoder_get_string(char* user_buf, unsigned int len);

#endif /* SENML_ENCODE */
