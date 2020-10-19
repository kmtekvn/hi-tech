Merge ESP8266 Binaries Read Me
==============================

A simple program to merge the multiple (normally 4, but up to 6) binary files from the new ESP8266 firmware builds
into a single file for ease of downloading to the chip.

I created this file after having problems downloading the multiple files, in particular in version 
at_v0.20_on_SDKv0.9.3, the esp_init_data_default.bin file would give a "float divide by zero" error
when using ESP8266_Flasher. I found a suggestion that creating a single file should help, hence this program.

After downloading the zip file extract from \Binaries\BuildESP8266Flash\BuildESP8266Flash.exe and run the 
program, select the files and the offset into the merged file
Chose a file name and length for the merged file and click "Merge".
Defaults/suggestions are provided for each file and the required offset.

Official firmware can be downloaded from http://bbs.espressif.com/viewforum.php?f=5

Hardware Configuration
======================
To download the firmware, I use the Arduino IDE, with the Examples\Basics\BareMinimum sketch loaded.
I have run the ESP directly fromt he 5V Arduno, but this may well break at some point, so I use a 
level shifter.
Arduino Tx (pin 1) -> ESP Rx
Arduino Rx (pin 0) -> ESP Tx
ESP Gnd -> ground
ESP VCC -> 3V3 from Arduino
ESP CH_PD -> 3V3 from Arduino

For flashing only: 
ESP GPIO2 -> ground

Flashing Tools
==============
The tool I used was the ESP8266_Flasher (from https://docs.google.com/file/d/0B3dUKfqzZnlwVGc1YnFyUjgxelE/edit)
I tried using the NodeMCU flasher (https://github.com/nodemcu/nodemcu-flasher) but that was never able to find 
my ESP, so never downloaded (or some other part of my setup was incorrect).
One tool that lots of people seem to like is esptool-py (https://github.com/themadinventor/esptool), 
however I did not have Python installed and would rather not have to install another tool to get this to work.

Note: If you pull ESP GPIO2 to ground permentantly, then the included flashing tool will report failure to
leave flashing mode when done, this is normal. Power off, disconnect GPIO2 and power on.

Useful Information
==================
I had not originally intended to update the firmware, having read a lot of information and finding people
were having problems. However, after trying to experiment with the "Cloud Update" feature, using the 
AT+CIOUPDATE command, the ESP got into a state where the blue LED flashed continuously and a large amount 
of junk symbols were returned from it. Power-cycling the unit did not get it out of this mode.

I then read online that this meant the firmware needed updating, hence my experiment into this!

As mentioned above, I had problems updating using multiple files, and again read that I should use the 
single file, but I could not find (many of) these online.



I hope this program is helpful to someone!