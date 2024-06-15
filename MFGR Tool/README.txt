Setup Instructions:
1. Use the packaged installer “as-installer-7.0.1931-web.exe” to install Atmel Studio in the default windows directory "C:\Program Files (x86)\"
     -make sure you install all of the files suggested
2. Plug in the Atmel device, Psoc device, and Barcode scanner in usb ports on your PC.
3. Install the Barcode scanner's usb drivers via running the setup.bat file enclosed in the "serialDriver" folder as an Administrator. Read its README for further info.
4. Run “MFGR Helper.exe” file.

General Usage Info:
-Uncheck boxes on the left side to change parameters which will be encoded
-These fields correspond to the device's settings.
-Using the "File" dropdown you can save these parameters or reload them to the saved values
-Press the "Program" button to program the devices with all the current parameters
-Using the "Options" dropdown you can access the admin menu with a password to alter internal parameters

Admin Info:
-Within the admin menu the "File" dropdown will allow you to save and return, cancel alterations and return, or reload the current saved settings
-Hex files are chosen by selecting a file via the browse feature, you can put your hex file in the default "\Resources\MFGR_Hex\" directory and choose it with the program,
  or you can browse to your own directory with your hex file.
-If you wish to rename the hex file being used you will need to use the browse button to choose the renamed file, otherwise a blank file with the old filename will be created.
-Similarly you can choose a directory for where Datalog files go, the default is created on program launch.

Additional Info:
-If the device being programmed is turned off unexpectedly reset the device after turning it back on

