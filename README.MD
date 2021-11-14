# Asbru-CM Runner

Asbru-CM-Runner is an application that lets you run the SSH client [Asbru-CM](https://www.asbru-cm.net) in Windows (which is usually only available on Linux) without having a console window always open in the background.

# Installation
1. Install [Xming](http://www.straightrunning.com/XmingNotes/)
2. Enable [WSL](https://docs.microsoft.com/en-us/windows/wsl/install-win10) In Windows 10 and enable WSL2. Note: If you are on an older build of Windows 10 (Pre 1903), you won't be able to enable WSL2. I have not tried this without WSL2 but I think that it should still work.
3. Install [Ubuntu](https://www.microsoft.com/en-us/p/ubuntu/9nblggh4msv6?activetab=pivot:overviewtab) from the Microsoft Store. Do not visit Ubuntu.com. You need to get the specific  Ubuntu image for WSL from the MS Store.
4. Make sure Asbru works when you manually run it
   a. Run Xming. The app icon should appear in the system tray at the bottom right.
   b. Open a bash.exe prompt from the run menu
   c. Run the command `export DISPLAY=:0`
   d. `Run sudo curl -1sLf 'https://dl.cloudsmith.io/public/asbru-cm/release/cfg/setup/bash.deb.sh' | sudo -E bash && sudo apt-get update && sudo install -y asbru-cm`
   e. Run `asbru-cm  &` and make sure that Asbru starts correctly. Once it displays the main window, you can close Asbru-CM.
5. Asbru-CM-Runner will look for Xming.exe in the default location (C:\Program Files (x86)\Xming) and for bash.exe in the default location (C:\Windows\system32\). If either of these executables are not installed in the default location, you can manually set them with the arguments `--xmingPath="C:\Program Files\Xming\xming.exe"` or `--bashPath=C:\Windows\System32\bash.exe`. Please note that if the path has spaces, you must wrap them in quotation marks. The path passed with the argument --xmingPath must end in xming.exe or it will be ignored. The same  is true for the argument --bashPath which must end in bash.exe or it will be ignored.
