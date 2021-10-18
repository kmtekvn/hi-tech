/**
 * Simple example to demo the esp-link MQTT client
 */

#include <ELClient.h>
#include <ELClientCmd.h>
#include <ELClientMqtt.h>
/*********** PART 1 - OBJECT / VARIABLE DECLARATIONi & PROTOTYPE ****************/
// Initialize a connection to esp-link using the normal hardware serial port both for
// SLIP and for debug messages.
// Serial: ket noi PC
// Serial1 (TX1, RX1) <=> ESP
ELClient esp(&Serial1, &Serial);

// Initialize CMD client (for GetTime)
// Method:  ELClientCmd(ELClient* elc);
// & -> get variable/object address operator
// ELClient* => Pointer to data type ELClient

ELClientCmd cmd(&esp); 

// Initialize the MQTT client
// Method prototype:  ELClientMqtt(ELClient* elc);
ELClientMqtt mqtt(&esp);

static int      count;
static uint32_t last;
bool connected;

#define  LED_PIN_NUM    13
#define  LED_OFF_CMD    "led_off"
#define  LED_ON_CMD     "led_on"

#define  MQTT_CONTROL_TOPIC  "arduino/control"
/*************PART 2: ARDUINO MAIN FUNCTIONS*****************************************/
/*
 * setup()-> Run only once at startup
 * void loop() -> Run repeatly
*/
void setup() {
  /* Setup Hardware Driver: UART Debug & UART SLIP (TO ESP) */
  Serial.begin(115200); // UART debug: 115200 => Baudrate unit kbps
  Serial1.begin(115200);  // UART SLIP
  pinMode(LED_PIN_NUM, OUTPUT);  // Set pin LED output mode
  Serial.println("EL-Client starting!"); // in va xuong dong println = print line -> Append <CR><LF>

  /* Check connection with ESP => Send SLIP command to ESP & Waiting the response */
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
  mqtt.publishedCb.attach(mqttPublished); // Da gui duoc goi tin
  mqtt.dataCb.attach(mqttData); // Xu ly data gui tu ESP
  
  mqtt.setup(); // Gui thong tin cai dat toi ESP

  Serial.println("EL-MQTT ready");
}


void processRemoteCmd(String cmd)
{
  int pwm = cmd.toInt();  // convert String to Interger
  analogWrite(LED_PIN_NUM, pwm);
  
#if 0  
  if (cmd == LED_OFF_CMD)
  {
    digitalWrite(LED_PIN_NUM, LOW);
  }

  if (cmd == LED_ON_CMD)
  {
    digitalWrite(LED_PIN_NUM, HIGH);
  } 
#endif
}

void test_send_mqtt_data(void)
{
    char buf[64] = {0};
    Serial.println("publishing");
    
    // itoa(count++, buf, 10); // integer to ascii
    sprintf(buf, ">>>Counter = %d <<<", count++); // format string & retarget to buffer 
    // combine text + number
   
    mqtt.publish("/esp-link/1", buf, 1);
    /*
    qos : 0, retain : false, cmd : publish, dup : false, topic : /esp-link/1, messageId : , length : 15, Raw payload : 4956
    qos = 1 => subscribe client must be qos=1
    */
#if 0
    itoa(count+99, buf, 10);
    mqtt.publish("/hello/world/arduino", buf);

    uint32_t t = cmd.GetTime();
    Serial.print("Time: "); 
    Serial.println(t);
#endif    
}

void loop() {
  esp.Process(); // Check & parse SLIP frame sent from ESP 
                 //  dispatch & invoke callback

  // millis() -> return current time stamp in MS (millisecond)
  // 4000ms = 4 second
  // connected: sucessfully establish connection
  if (connected && (millis()-last) > 4000) 
  {
    test_send_mqtt_data(); // Sending data over mqtt
    last = millis();
  }
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


// Callback when MQTT is connected
void mqttConnected(void* response) {
  Serial.println("MQTT connected!");
 // mqtt.subscribe("/esp-link/1"); // Register topic to mqtt broker
  mqtt.subscribe(MQTT_CONTROL_TOPIC);  // # - listen all sub topic
                                     // /hello/world/1 /hello/world/2

  connected = true;
}

// Callback when MQTT is disconnected
void mqttDisconnected(void* response) {
  Serial.println("MQTT disconnected");
  connected = false;
}

// Callback when an MQTT message arrives for one of our subscriptions
void mqttData(void* response) {
  // ELClientResponse -> class parse & get payload data
  ELClientResponse *res = (ELClientResponse *)response;

  // ESP sends frame include Topic (string) + Payload (string)
  Serial.print("Received: topic=");
  String topic = res->popString();
  Serial.println(topic);

  Serial.print("data=");
  String data = res->popString();
  Serial.println(data);

  processRemoteCmd(data);
}

void mqttPublished(void* response) {
  Serial.println("MQTT published");
}
