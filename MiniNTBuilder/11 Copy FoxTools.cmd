call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy /y "%FoxTools%\FoxTools\bin\Release\FoxTools.exe" "%minintx64%\Windows"

"%FoxTools%\LicenseMerge\bin\Release\LicenseMerge.exe" "%FoxTools%\FoxTools\Foxy MiniNT.lic" "%minintx64%\Windows\FoxTools.exe"

Dism /Unmount-Image /MountDir:"%minintx64%" /commit
