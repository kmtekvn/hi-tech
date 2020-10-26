#include "main_process.h"

void setup() {
  Main_InitHw();
  Main_InitLibs();
}

void loop()
{
  Main_ProcessLoop();
}