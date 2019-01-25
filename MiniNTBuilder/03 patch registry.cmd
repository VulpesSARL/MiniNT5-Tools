call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

reg load HKLM\0000 "%minintx86%\Windows\system32\config\system"
reg import Registry\SYSTEM.reg
reg unload HKLM\0000

reg load HKLM\0000 "%minintx64%\Windows\system32\config\system"
reg import Registry\SYSTEM.reg
reg unload HKLM\0000


reg load HKLM\0000 "%minintx86%\Windows\system32\config\software"
echo Manually Patch Permissions on HKEY_LOCAL_MACHINE\0000\Microsoft\WindowsRuntime to allow write!
pause
reg import Registry\SOFTWARE.reg
reg unload HKLM\0000

reg load HKLM\0000 "%minintx64%\Windows\system32\config\software"
echo Manually Patch Permissions on HKEY_LOCAL_MACHINE\0000\Microsoft\WindowsRuntime to allow write!
pause
reg import Registry\SOFTWARE.reg
reg unload HKLM\0000


reg load HKLM\0000 "%minintx86%\Windows\system32\config\default"
reg import Registry\DEFAULT.reg
reg unload HKLM\0000

reg load HKLM\0000 "%minintx64%\Windows\system32\config\default"
reg import Registry\DEFAULT.reg
reg unload HKLM\0000



Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit

