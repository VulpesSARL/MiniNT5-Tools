call paths.cmd

call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=Win32
timeout 30

call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=x64
timeout 30

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy ..\Release\FoxCommon.dll "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxCWrapper.dll "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxCWrapperWIM.dll "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxMapNet.exe "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxMultiWIM.exe "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxSetKeyboard.exe "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxShell.exe "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxShellIcon.exe "%minintx86%\Windows\Fox" /y
copy ..\Release\FoxUnmapNet.exe "%minintx86%\Windows\Fox" /y


copy ..\x64\Release\FoxCommon.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapper.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapperWIM.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMapNet.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMultiWIM.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxSetKeyboard.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShell.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShellIcon.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxUnmapNet.exe "%minintx64%\Windows\Fox" /y


Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit

