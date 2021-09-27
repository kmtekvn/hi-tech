#include "hello.h"

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Serial.println( get_welcome_string() );
}

void loop() {
  // put your main code here, to run repeatedly:

}
