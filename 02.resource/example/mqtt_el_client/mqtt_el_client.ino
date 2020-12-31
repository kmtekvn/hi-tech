/**
 * Simple example to demo the esp-link MQTT client
 */

#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>

#include <movingAvg.h>                  // https://github.com/JChristensen/movingAvg
#include "MAX30105.h"  //Get it here: http://librarymanager/All#SparkFun_MAX30105
#include <kpn_senml.h>

MAX30105 particleSensor;
movingAvg temperatureSensor(10);                // define the moving average object

SenMLPack doc("sensor");
// Tao record theo format Temperature
SenMLFloatRecord rec(KPN_SENML_TEMPERATURE, SENML_UNIT_DEGREES_CELSIUS, 0);                 

// Initialize a connection to esp-link using the normal hardware serial port both for
// SLIP and for debug messages.
ELClient esp(&Serial1);

// Initialize CMD client (for GetTime)
ELClientCmd cmd(&esp);

// Initialize the MQTT client
ELClientMqtt mqtt(&esp);

// SenML
void senml_format_init()
{
  senMLSetLogger(&Serial);
  doc.add(&rec);
}
void senml_format_encode(float val, const char* buffer, int buf_size)
{
  rec.set(val);
  memset(buffer,0, buf_size);            
  doc.toJson(buffer, buf_size);
}
// Sensor group
void sensor_setup()
{
  temperatureSensor.begin();
    // Initialize sensor
  if (particleSensor.begin(Wire, I2C_SPEED_FAST) == false) //Use default I2C port, 400kHz speed
  {
    Serial.println("MAX30105 was not found. Please check wiring/power. ");
    while (1);
  }
   particleSensor.setup(0); //Configure sensor. Turn off LEDs
   particleSensor.enableDIETEMPRDY(); //Enable the temp ready interrupt. This is required.
}

float sensor_process()
{
  float temperature = particleSensor.readTemperature();
  float avgTemp = temperatureSensor.reading(temperature); 

  return avgTemp;
}

void el_client_send_msg(char* buf)
{
    mqtt.publish("/hello/world/arduino", buf);
    uint32_t t = cmd.GetTime();
    Serial.print("Time: "); Serial.println(t);
}
 
// Callback made from esp-link to notify of wifi status changes
// Here we just print something out for grins
void wifiCb(void* response) {
  ELClientResponse *res = (ELClientResponse*)response;
  if (res->argc() == 1) {
    uint8_t status;
    res->popArg(&status, 1);

    if(status == STATION_GOT_IP) {
      Serial.println("WIFI CONNECTED");
    } else {
      Serial.print("WIFI NOT READY: ");
      Serial.println(status);
    }
  }
}

bool connected;

// Callback when MQTT is connected
void mqttConnected(void* response) {
  Serial.println("MQTT connected!");
  mqtt.subscribe("/esp-link/1");
  //mqtt.subscribe("/hello/world/#");
  //mqtt.subscribe("/esp-link/2", 1);
  //mqtt.publish("/esp-link/0", "test1");
  connected = true;
}

// Callback when MQTT is disconnected
void mqttDisconnected(void* response) {
  Serial.println("MQTT disconnected");
  connected = false;
}

// Callback when an MQTT message arrives for one of our subscriptions
void mqttData(void* response) {
  ELClientResponse *res = (ELClientResponse *)response;

  Serial.print("Received: topic=");
  String topic = res->popString();
  Serial.println(topic);

  Serial.print("data=");
  String data = res->popString();

  // Dieu khien LED
  if (data == "on")
  {
    digitalWrite(LED_BUILTIN, HIGH);
  }else if (data == "off")
  {
    digitalWrite(LED_BUILTIN, LOW);
  }

  Serial.println(data);
}

void mqttPublished(void* response) {
  Serial.println("MQTT published");
}

void setup() {
  sensor_setup();
  pinMode(LED_BUILTIN, OUTPUT);
  
  Serial1.begin(115200);
  Serial.begin(115200);
  senml_format_init();
  
  Serial.println("EL-Client starting!");
  
  // Sync-up with esp-link, this is required at the start of any sketch and initializes the
  // callbacks to the wifi status change callback. The callback gets called with the initial
  // status right after Sync() below completes.
  esp.wifiCb.attach(wifiCb); // wifi status change callback, optional (delete if not desired)
  bool ok;
  do {
    ok = esp.Sync();      // sync up with esp-link, blocks for up to 2 seconds
    if (!ok) Serial.println("EL-Client sync failed!");
  } while(!ok);
  Serial.println("EL-Client synced!");

  // Set-up callbacks for events and initialize with es-link.
  mqtt.connectedCb.attach(mqttConnected);
  mqtt.disconnectedCb.attach(mqttDisconnected);
  mqtt.publishedCb.attach(mqttPublished);
  mqtt.dataCb.attach(mqttData);
  mqtt.setup();

  //Serial.println("ARDUINO: setup mqtt lwt");
  //mqtt.lwt("/lwt", "offline", 0, 0); //or mqtt.lwt("/lwt", "offline");

  Serial.println("EL-MQTT ready");
}

static int count;
static uint32_t last;
static float sensorData = 0.0;

#define SENML_DOC_BUFFER_SIZE  128
static char buf[SENML_DOC_BUFFER_SIZE];
void loop() {
  esp.Process();
  if (connected && (millis()-last) > 1000) {
    Serial.println("publishing");
   // Doc cam bien 
    sensorData = sensor_process();
    Serial.println(sensorData, 4);
    senml_format_encode(sensorData, buf, SENML_DOC_BUFFER_SIZE);
    Serial.println(buf);
    // Gui sensor data qua MQTT
    el_client_send_msg(buf);
    last = millis();
  }
}
