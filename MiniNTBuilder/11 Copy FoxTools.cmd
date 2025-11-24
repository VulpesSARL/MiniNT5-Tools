REM call paths.cmd

REM "04 copy files.cmd" already does it!

REM Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

REM copy /y "%FoxTools%\FoxTools\bin\Release\FoxTools.exe" "%minintx64%\Windows"

REM "%FoxTools%\LicenseMerge\bin\Release\LicenseMerge.exe" "%FoxTools%\FoxTools\Foxy MiniNT.lic" "%minintx64%\Windows\FoxTools.exe"

REM Dism /Unmount-Image /MountDir:"%minintx64%" /commit
