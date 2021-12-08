# Asbru-CM Runner

Asbru-CM-Runner is an application that lets you run the really great SSH client [Asbru-CM](https://www.asbru-cm.net) in Windows (which is usually only available on Linux) without having a console window always open in the background.

# Installation
1. Install [Xming](http://www.straightrunning.com/XmingNotes/) follow the prompts and run it.
3. The latest instructions from Microsoft suggest that you open a Powershell and run wsl --install. I had to specify Ubuntu as my Distro by doing `wsl --install -d ubuntu` and follow the prompts creating the user until you get to a bash prompt.
4. Make sure Asbru works when you manually run it
   a. Run Xming if it's not running already. The app icon should appear in the system tray at the bottom right.
   b. Open a bash.exe prompt from the run menu
   c. Run the command `export DISPLAY=:0`
   d. `Run sudo curl -1sLf 'https://dl.cloudsmith.io/public/asbru-cm/release/cfg/setup/bash.deb.sh' | sudo -E bash && sudo apt update && sudo apt install -y asbru-cm`
   e. Run `asbru-cm  &` and make sure that Asbru starts correctly. Once it displays the main window, you can close Asbru-CM.
5. Asbru-CM-Runner will look for Xming.exe in the default location (C:\Program Files (x86)\Xming) and for bash.exe in the default location (C:\Windows\system32\). If either of these executables are not installed in the default location, you can manually set them with the arguments `--xmingPath="C:\Program Files\Xming\xming.exe"` or `--bashPath=C:\Windows\System32\bash.exe`. Please note that if the path has spaces, you must wrap them in quotation marks. The path passed with the argument --xmingPath must end in xming.exe or it will be ignored. The same  is true for the argument --bashPath which must end in bash.exe or it will be ignored.
