The esp8266_flash.exe application is what I have used to flash my ESP8266.

It was originally downloaded from here: https://drive.google.com/file/d/0B3dUKfqzZnlwVGc1YnFyUjgxelE/view?usp=sharing
References to this download:
1. http://www.xess.com/blog/esp8266-reflash/
2. https://importhack.wordpress.com/2014/11/22/how-to-use-ep8266-esp-01-as-a-sensor-web-client/

It only appears to be able to write from address 0, hence needing to give ti the firmware in a single file.

Included are some sample files:
ESP_8266_BIN0.92 & v0.9.2.2 AT Firmware were downloaded from the web for references.
Note: v0.9.2.2 AT Firmware.bin sets the rate to 9600 using CrLf

v0.9.3.0 AT Firmware.bin was created using the tool. The source files were from:
http://bbs.espressif.com/viewtopic.php?f=5&t=64
Note: it sets the rate to 115200 using CrLf

Note: In versions < 0.9.2.2, the change baud rate command is AT+CIOBAUD=9600
In 0.9.3.0, the command is AT+IPR=9600