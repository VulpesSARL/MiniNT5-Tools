call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"


takeown /r /a /f "%minintx64%\Windows\system32\Config" > NUL:
icacls "%minintx64%\Windows\system32\Config" /grant Administrators:(oi)(ci)F /c /t /q
takeown /r /a /f "%minintx86%\Windows\system32\Config" > NUL:
icacls "%minintx86%\Windows\system32\Config" /grant Administrators:(oi)(ci)F /c /t /q

mkdir "%minintx64%\Windows\Profiles"
move "%minintx64%\Windows\system32\Config\Systemprofile" "%minintx64%\Windows\Profiles" 

mkdir "%minintx86%\Windows\Profiles"
move "%minintx86%\Windows\system32\Config\Systemprofile" "%minintx86%\Windows\Profiles" 

reg load HKLM\0000 "%minintx86%\Windows\system32\config\software"
reg add "HKLM\0000\Microsoft\Windows NT\CurrentVersion\ProfileList\S-1-5-18" /v "ProfileImagePath" /t REG_EXPAND_SZ /d ^%systemroot^%\Profiles\Systemprofile /f
reg unload HKLM\0000



reg load HKLM\0000 "%minintx64%\Windows\system32\config\software"
reg add "HKLM\0000\Microsoft\Windows NT\CurrentVersion\ProfileList\S-1-5-18" /v "ProfileImagePath" /t REG_EXPAND_SZ /d ^%systemroot^%\Profiles\Systemprofile /f
reg unload HKLM\0000


Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit
