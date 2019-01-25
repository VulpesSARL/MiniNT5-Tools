call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

takeown /r /a /f "%minintx64%\windows\WinSxS" > NUL:
icacls "%minintx64%\windows\WinSxS" /grant Administrators:(oi)(ci)F /c /t /q

copy /y "%winx64%\windows\system32\wow64.dll" "%minintx64%\windows\system32"
copy /y "%winx64%\windows\system32\wow64cpu.dll" "%minintx64%\windows\system32"
copy /y "%winx64%\windows\system32\wow64win.dll" "%minintx64%\windows\system32"
copy /y "%winx64%\windows\syswow64\vdmdbg.dll" "%minintx64%\windows\syswow64"

copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-ApisetNamespace-WOW64-*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"
copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-CoreSystem-WOW64-*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"
copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-Client-Drivers-Package-net~*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"
copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-Client-Features-Package-net~*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"
copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-SKU-Foundation-Package-net~*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"
copy /y "%winx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\Microsoft-Windows-Client-Drivers-Package-drivers~*.cat" "%minintx64%\windows\system32\catroot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}"

pushd "%winx64%\windows\WinSxS"
FOR /d %%a in ("x86_microsoft.windows.common-controls_*") DO xcopy /e /r /h /y /f "%winx64%\windows\WinSxS\%%a" "%minintx64%\windows\WinSxS\%%a\"
FOR /d %%a in ("x86_microsoft.windows.c..-controls.resources_*") DO xcopy /e /r /h /y /f "%winx64%\windows\WinSxS\%%a" "%minintx64%\windows\WinSxS\%%a\"
FOR /d %%a in ("x86_microsoft.windows.gdiplus*") DO xcopy /e /r /h /y /f "%winx64%\windows\WinSxS\%%a" "%minintx64%\windows\WinSxS\%%a\"
FOR /d %%a in ("x86_microsoft.windows.isolationautomation_*") DO xcopy /e /r /h /y /f "%winx64%\windows\WinSxS\%%a" "%minintx64%\windows\WinSxS\%%a\"
popd

copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.gdiplus_6595b64144ccf1df*.*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.common-controls_*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.c..-controls.resources_*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.i..utomation.proxystub_*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.isolationautomation_*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft.windows.systemcompatible_*" "%minintx64%\windows\WinSxS\Manifests"
copy /y "%winx64%\windows\WinSxS\Manifests\x86_microsoft-windows-m..tion-isolationlayer_*" "%minintx64%\windows\WinSxS\Manifests"


..\Release\CollectWOW64.exe "%minintx64%" "%winx64%" tmp_copywow64.cmd en-US
call tmp_copywow64.cmd
del tmp_copywow64.cmd

reg load HKLM\0000 "%minintx64%\Windows\system32\config\software"
regedit /s Registry\WOW64\SxS.reg
regedit /s Registry\WOW64\SMI.reg
regedit /s Registry\WOW64\Cryptography.reg
regedit /s Registry\WOW64\CLSID1.reg
regedit /s Registry\WOW64\CLSID2.reg
reg unload HKLM\0000

Dism /Unmount-Image /MountDir:"%minintx64%" /commit

