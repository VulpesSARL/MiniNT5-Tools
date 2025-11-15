call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

mkdir "%minintx64%\Windows\Resources\Themes\aero\Shell\NormalColor"
mkdir "%minintx64%\Windows\Resources\Themes\aero\Shell\NormalColor\en-us"
copy "%winx64%\windows\system32\netplwiz.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\netplwiz.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\explorerframe.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\explorerframe.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\avicap32.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\avicap32.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\msvfw32.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\msvfw32.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\shellstyle.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\shellstyle.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\Resources\Themes\aero\Shell\NormalColor\shellstyle.dll" "%minintx64%\Windows\Resources\Themes\aero\Shell\NormalColor"
copy "%winx64%\windows\Resources\Themes\aero\Shell\NormalColor\en-us\shellstyle.dll.mui" "%minintx64%\windows\Resources\Themes\aero\Shell\NormalColor\en-us"
copy "%winx64%\windows\system32\thumbcache.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\thumbcache.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\twinapi.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\twinapi.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\twinapi.appcore.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\twinapi.appcore.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\chartv.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\chartv.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\actxprxy.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\actxprxy.dll.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\shfolder.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\shfolder.dll.mui" "%minintx64%\windows\system32\en-us"

copy "%winx64%\windows\system32\rmclient.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\Windows.UI.Cred.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\cscapi.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\policymanager.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\sc.exe" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\en-us\sc.exe.mui" "%minintx64%\windows\system32\en-us"
copy "%winx64%\windows\system32\glu32.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\opengl32.dll" "%minintx64%\windows\system32"
copy "%winx64%\windows\system32\dxcore.dll" "%minintx64%\windows\system32"



Dism /Unmount-Image /MountDir:"%minintx64%" /commit

