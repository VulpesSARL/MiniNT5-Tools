call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

mkdir "%minintx64%\Windows\Tools"

xcopy /y /e /h /r /c /f Files\Tools64\*.* "%minintx64%\Windows\Tools"

Dism /Unmount-Image /MountDir:"%minintx64%" /commit

