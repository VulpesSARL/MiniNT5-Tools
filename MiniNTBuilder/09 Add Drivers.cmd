call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"


Dism /Image:"%minintx86%" /Add-Driver /driver:"Drivers\x86" /recurse
Dism /Image:"%minintx64%" /Add-Driver /driver:"Drivers\x64" /recurse




Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit
