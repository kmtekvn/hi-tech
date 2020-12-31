#include <kpn_senml.h>

SenMLPack doc("sensor");

// Tao record theo format Temperature
SenMLFloatRecord rec(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, 0);                 
SenMLFloatRecord rec2(KPN_SENML_HUMIDITY, SENML_UNIT_RELATIVE_HUMIDITY, 0);

void setup(){
    Serial.begin(115200);
    senMLSetLogger(&Serial);
    delay(1000);
    Serial.println("start");
    doc.add(&rec);
    doc.add(&rec2);
}

void loop(){
    // Doc du lieu cam bien
    int val = digitalRead(1);  
    rec.set(val);
    rec2.set(75);
    
    char buffer[120];   
    memset(buffer,0, sizeof(buffer));       
         
    doc.toJson(buffer, sizeof(buffer));
    Serial.println(buffer);
    
  /*  memset(buffer,0,sizeof(buffer));  
    doc.toJson(buffer, sizeof(buffer), SENML_HEX);
    Serial.println(buffer);
   */
    delay(1000);
}
