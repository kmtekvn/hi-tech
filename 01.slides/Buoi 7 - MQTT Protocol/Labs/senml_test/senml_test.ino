#include "senml_encode.h"

#define MAX_SENML_STRING_BUFFER_LEN       128

static char buffer[MAX_SENML_STRING_BUFFER_LEN];

void setup(){
    Serial.begin(115200); // Setup debug port 
    /*TODO: Call senml encode init*/
    senml_encode_init();
    
    delay(1000);
    Serial.println("start");
}

void loop(){
   /*TODO: create senml record */                
   // Insert sensor value to data record
    int val = analogRead(1);    
    senml_encode_add_record(SENML_REC_TYPE_TEMP, val);
    
   /*TODO: convert senml record to string */
   senml_encoder_get_string(buffer, MAX_SENML_STRING_BUFFER_LEN);
   Serial.println(buffer);
       
   delay(1000);
}
