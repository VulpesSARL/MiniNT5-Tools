call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

Dism /Image:"%minintx64%" /Add-Driver /driver:"Drivers\x64" /recurse

Dism /Unmount-Image /MountDir:"%minintx64%" /commit
