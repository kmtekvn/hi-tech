/*
  Blink

  Turns an LED on for one second, then off for one second, repeatedly.

  Most Arduinos have an on-board LED you can control. On the UNO, MEGA and ZERO
  it is attached to digital pin 13, on MKR1000 on pin 6. LED_BUILTIN is set to
  the correct LED pin independent of which board is used.
  If you want to know what pin the on-board LED is connected to on your Arduino
  model, check the Technical Specs of your board at:
  https://www.arduino.cc/en/Main/Products

  modified 8 May 2014
  by Scott Fitzgerald
  modified 2 Sep 2016
  by Arturo Guadalupi
  modified 8 Sep 2016
  by Colby Newman

  This example code is in the public domain.

  http://www.arduino.cc/en/Tutorial/Blink
*/

/* Dinh nghia kieu du lieu */
typedef enum 
{
  STATE_WAIT_COMMAND = 0x00,
  STATE_BLINKING
} eArduinoState;

typedef unsigned char uint8_t;

static uint8_t cmd = STATE_WAIT_COMMAND;
// Cac module xu ly rieng biet (dang function)

uint8_t _wait_incoming_cmd(void) {
  // cho nhan command 
}

void _blink_led(void) {
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(1000);                       // wait for a second
  digitalWrite(LED_BUILTIN, LOW);    // turn the LED off by making the voltage LOW
  delay(1000);
}
// Cac ham cua arduino

// the setup function runs once when you press reset or power the board
void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(LED_BUILTIN, OUTPUT);
}

// the loop function runs over and over again forever
void loop() {
   switch (cmd)
   {
    case STATE_WAIT_COMMAND:
      cmd = _wait_incoming_cmd();
    break;
    case STATE_BLINKING:
      _blink_led();
      cmd = STATE_WAIT_COMMAND;
      break;
    default:
     cmd = STATE_WAIT_COMMAND;
     break;
   }
}
