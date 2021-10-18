#include <kpn_senml.h>

SenMLPack doc("device_name"); // Create document (message) - basename (multi datapoint)

void setup(){
    Serial.begin(115200); // Setup debug port 
    
    senMLSetLogger(&Serial); // Debug port for SenML library
    
    delay(1000);
    Serial.println("start");
}

void loop(){
    SenMLBoolRecord rec(KPN_SENML_TEMPERATURE); // Create data record 

    // Insert sensor value to data record
    int val = analogRead(1);    
    rec.set(val);

    // Attach record to frame
    doc.add(&rec);                      

    char buffer[120];   

    // Output character string
    memset(buffer,0, sizeof(buffer));            
    doc.toJson(buffer, sizeof(buffer));
    Serial.println(buffer);
    /* [{"bn":"device_name","n":"temperature","vb":true}] */


    delay(1000);
}
