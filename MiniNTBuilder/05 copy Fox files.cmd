call paths.cmd

call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=x64
timeout 30

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy ..\x64\Release\FoxCommon.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapper.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapperWIM.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMapNet.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMultiWIM.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxSetKeyboard.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShell.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShellIcon.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxUnmapNet.exe "%minintx64%\Windows\Fox" /y


Dism /Unmount-Image /MountDir:"%minintx64%" /commit

