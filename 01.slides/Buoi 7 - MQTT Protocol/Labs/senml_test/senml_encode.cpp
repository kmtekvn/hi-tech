#include "senml_encode.h"
#include <Arduino.h>
#include <kpn_senml.h> /* Look header file in libraries folder */

//  device_name: Is used to represent the name of the device.
SenMLPack doc(SENML_DEVICE_NAME); // Create document (message) - basename (multi datapoint)

 /* [{"bn":"device_name","n":"temperature","vb":true}] */

void senml_encode_init()
{
  senMLSetLogger(&Serial); // Debug port for SenML library
}

void senml_encode_add_record(unsigned char rec_type, int val)
{
  char* record_name = NULL;
  
  switch (rec_type)
  {
    case SENML_REC_TYPE_TEMP:
         record_name = KPN_SENML_TEMPERATURE;
         break;
    default:
         break;
  }

  if (record_name != NULL)
  {
    SenMLBoolRecord rec(record_name); // Create data record 
    rec.set(val);
    // Attach record to frame
    doc.add(&rec);      
  }
}

void senml_encoder_get_string(char* user_buf, unsigned int len)
{
    // Output character string
    memset(user_buf,0, len);            
    doc.toJson(user_buf, len);
}
