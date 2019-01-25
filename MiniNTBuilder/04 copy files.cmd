call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

xcopy /y /e /h /r /c /f Files\General\*.* "%minintx86%"
xcopy /y /e /h /r /c /f Files\General\*.* "%minintx64%"

xcopy /y /e /h /r /c /f Files\x86\*.* "%minintx86%"
xcopy /y /e /h /r /c /f Files\x64\*.* "%minintx64%"

Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit

