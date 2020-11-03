#ifndef LOGGER_H_
#define LOGGER_H_

#include "config.h"


#if CONFIG_LOGGER_EN
	#define logging_SendDebug(msg)  do { Serial.println(msg); } while(0);
#else
	#define logging_SendDebug(msg)	
#endif /* CONFIG_LOGGER_EN */

void logging_Setup(void);

#endif /* LOGGER_H_ */
