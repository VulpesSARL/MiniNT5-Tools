call paths.cmd

call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=x64
timeout 30

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy ..\x64\Release\FoxCommon.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapper.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxCWrapperWIM.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMapNet.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMapNet.exe.config "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMultiWIM.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxMultiWIM.exe.config "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxSetKeyboard.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxSetKeyboard.exe.config "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShell.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShell.exe.config "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShellIcon.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxShellIcon.exe.config "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxUnmapNet.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxUnmapNet.exe.config "%minintx64%\Windows\Fox" /y

copy ..\x64\Release\DiscUtils.Containers.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Core.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Dmg.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Iso9660.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Net.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.OpticalDiscSharing.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Streams.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Vhd.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Vhdx.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Vmdk.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Wim.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\DiscUtils.Xva.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\lzfse-net.dll "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxDiskToVHDX.exe "%minintx64%\Windows\Fox" /y
copy ..\x64\Release\FoxDiskToVHDX.exe.config "%minintx64%\Windows\Fox" /y


Dism /Unmount-Image /MountDir:"%minintx64%" /commit

