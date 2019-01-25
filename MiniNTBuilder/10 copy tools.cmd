call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

mkdir "%minintx86%\Windows\Tools"
mkdir "%minintx64%\Windows\Tools"

xcopy /y /e /h /r /c /f Files\Tools32\*.* "%minintx86%\Windows\Tools"
xcopy /y /e /h /r /c /f Files\Tools64\*.* "%minintx64%\Windows\Tools"

Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit

