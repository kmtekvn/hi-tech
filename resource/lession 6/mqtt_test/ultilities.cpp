/* SenML format library */
#include <kpn_senml.h>

#define SENML_DOC_BUFFER_SIZE  120


// Define device object
SenMLPack doc("gateway");
SenMLPack dev1("dev1");

// Define record object
SenMLFloatRecord rec1(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, 0);
SenMLFloatRecord rec2(KPN_SENML_BREADTH, SENML_UNIT_BEATS, 0);

void Ultil_SenMLInit(void)
{
  senMLSetLogger(&Serial);
  doc.add(&dev1);
  dev1.add(&rec1);
  dev1.add(&rec2);
}

void Ultil_MakeSenMLFrame(sensorData_t* sensorStructP,  char* retFrameP) 
{
 rec1.set(sensorStructP->temperature);
 rec2.set(sensorStructP->heartbeat);
 doc.toJson(retFrameP, SENML_DOC_BUFFER_SIZE);  
}






