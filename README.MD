# Asbru-CM Runner

Asbru-CM-Runner is an application that runs the really great SSH client [Asbru-CM](https://www.asbru-cm.net) in Windows even though it is a Linux-only application. Asbru-CM-Runner does not leave a console window open and runs in the background. It works by using [WSL](https://learn.microsoft.com/en-us/windows/wsl/install) to launch Asbru-CM.

If you are not using [WSLg](https://github.com/microsoft/wslg), you will need to install the Windows X Window Manager [Xming](http://www.straightrunning.com/XmingNotes/)
If you are using WSLg, Asbru-CM-Runner will try to automatically detect this by looking for `C:\Windows\System32\wslg.exe` and will not require or attempt to run XMing.

# Setup
1. (Without WSLg) Install [Xming](http://www.straightrunning.com/XmingNotes/) follow the prompts and run it. You should see the XMing icon in the system tray that indicates that it is running in the bacground.
1. Install a Linux distro in WSL: If you haven't done so already, install a Linux distro in WSL. The latest instructions from Microsoft suggest that you open a Powershell window and run `wsl --install`. I had to specify Ubuntu as my distro by doing `wsl --install -d ubuntu` and follow the prompts including creating the user account. When you get to a bash prompt, do not close it.
1. Make sure Asbru-CM works when you manually run it
   - (Without WSLg) Run Xming if it's not running already. The app icon should appear in the system tray at the bottom right.
   - Open an Ubuntu shell prompt from the Windows menu if it is not open already.
   - (Without WSLg) Run the command `export DISPLAY=:0` to redirect the user interface to XMing.
   - Install ASbru-CM in WSL: Run `sudo curl -1sLf 'https://dl.cloudsmith.io/public/asbru-cm/release/cfg/setup/bash.deb.sh' | sudo -E bash && sudo apt update && sudo apt install -y asbru-cm`
   - Run `asbru-cm  &` and make sure that Asbru starts correctly. Once the main Asbru-CM window loads, you can close Asbru-CM.

# Command line arguments

+ Bash: Asbru-CM-Runner will look for bash.exe in the default location (C:\Windows\system32\bash.exe). If you want to specify a different location for bash.exe, you can use the command line argument `--bashPath=C:\somefolder\bash.exe`. Please note that if the path has spaces, you must wrap it in quotation marks like this: `--bashPath="C:\some folder\bash.exe"`. This path must end in bash.exe or it will be ignored.
+ XMing (No WSLg only): Asbru-CM-Runner will look for xming.exe in the default location (C:\Program Files (x86)\Xming\xming.exe). If you want to change this location, you can use the command line argument `--xmingPath=C:\somefolder\Xming\xming.exe`. Please note that if the path has spaces, you must wrap them in quotation marks. This path must end in xming.exe or it will be ignored.
+ Force WSLg mode: Asbru-CM-Runner will try to automatically detect if WSLg is avaialable by looking for the binary wslg.exe in `C:\Windows\System32\wslg.exe`. If this does not automatically detect WSLg, you can force WSLg mode this by providing the command line argument `--skip-xming=true`;

# Issues

If you installed Docker Desktop before installing WSL for the first time, then you may run into a situation where running wsl or bash simply does nothing. This happens because docker-desktop-data is the default WSL container instead of Ubuntu or whichever distro you installed.

To fix this, run the command `wsl --list --all --verbose` to list all WSL containers which should show output similar to this:

    NAME                   STATE           VERSION
    * docker-desktop       Stopped         2
    docker-desktop-data    Stopped         2
    Ubuntu                 Stopped         1

The output shows that docker-desktop is the default container because it has an asterick next to it.
To fix this, set the default container to Ubuntu:

`wsl --set-default Ubuntu`

Run the above command `wsl --list --all --verbose` again to verify that Ubuntu is now the default container.

    NAME                   STATE           VERSION
    docker-desktop         Stopped         2
    docker-desktop-data    Stopped         2
    *Ubuntu                Stopped         1
  
  
Solution credit goes to [https://superuser.com/questions/1661596/wsl-doesnt-want-to-launch](https://superuser.com/questions/1661596/wsl-doesnt-want-to-launch)
