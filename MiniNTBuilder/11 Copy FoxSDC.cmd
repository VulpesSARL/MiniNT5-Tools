call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

mkdir "%minintx86%\Windows\SDC"
mkdir "%minintx64%\Windows\SDC"

xcopy /y /e /h /r /c /f "%SDC%\SDC Agent" "%minintx86%\Windows\SDC"
xcopy /y /e /h /r /c /f "%SDC%\SDC Agent" "%minintx64%\Windows\SDC"

copy "%SDC%\FoxSDC_Agent_Setup64.msi" "%minintx86%\Windows\SDC"
copy "%SDC%\FoxSDC_Agent_Setup32.msi" "%minintx86%\Windows\SDC"
copy "%SDC%\FoxSDC_Agent_Setup64.msi" "%minintx64%\Windows\SDC"
copy "%SDC%\FoxSDC_Agent_Setup32.msi" "%minintx64%\Windows\SDC"

del "%minintx86%\Windows\SDC\FoxSDC_UninstallData.exe"
del "%minintx64%\Windows\SDC\FoxSDC_UninstallData.exe"

Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit
