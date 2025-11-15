call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

takeown /r /a /f "%minintx64%\Windows\system32\Config" > NUL:
icacls "%minintx64%\Windows\system32\Config" /grant Administrators:(oi)(ci)F /c /t /q

mkdir "%minintx64%\Windows\Profiles"
xcopy /e /y "%minintx64%\Windows\system32\Config\Systemprofile" "%minintx64%\Windows\Profiles"
rd /s /q "%minintx64%\Windows\system32\Config\Systemprofile"
mkdir "%minintx64%\Windows\Profiles\Systemprofile\Desktop"

reg load HKLM\0000 "%minintx64%\Windows\system32\config\software"
reg add "HKLM\0000\Microsoft\Windows NT\CurrentVersion\ProfileList\S-1-5-18" /v "ProfileImagePath" /t REG_EXPAND_SZ /d ^%systemroot^%\Profiles\Systemprofile /f
reg unload HKLM\0000


Dism /Unmount-Image /MountDir:"%minintx64%" /commit
