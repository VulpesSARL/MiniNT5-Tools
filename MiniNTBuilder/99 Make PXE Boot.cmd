call paths.cmd

attrib -r -h -s -a /s "..\PXEBoot"
rmdir /q /s "..\PXEBoot"

mkdir "..\PXEBoot"

mkdir "..\PXEBoot\BIOS"
mkdir "..\PXEBoot\BIOS\en-US"
mkdir "..\PXEBoot\BIOS\Boot"
mkdir "..\PXEBoot\BIOS\Sources"

mkdir "..\PXEBoot\EFI X86"
mkdir "..\PXEBoot\EFI X86\en-US"
mkdir "..\PXEBoot\EFI X86\Boot"
mkdir "..\PXEBoot\EFI X86\Sources"

mkdir "..\PXEBoot\EFI X64"
mkdir "..\PXEBoot\EFI X64\en-US"
mkdir "..\PXEBoot\EFI X64\Boot"
mkdir "..\PXEBoot\EFI X64\Sources"

mkdir "..\PXEBoot\EFI BC"

xcopy /e /d "..\Build32\Media\Boot" "..\PXEBoot\BIOS\Boot"
xcopy /e /d "..\Build32\Media\Sources" "..\PXEBoot\BIOS\Sources"
bcdedit /store "..\PXEBoot\BIOS\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\PXEBoot\BIOS\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize 10



xcopy /e /d "..\Build32\Media\EFI\Microsoft\Boot" "..\PXEBoot\EFI X86\Boot"
xcopy /e /d "..\Build32\Media\Sources" "..\PXEBoot\EFI X86\Sources"
copy "..\Build32\Media\Boot\Boot.sdi" "..\PXEBoot\EFI X86\Boot"
bcdedit /store "..\PXEBoot\EFI X86\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\PXEBoot\EFI X86\Boot\BCD" /set {bootmgr} Path \bootmgfw.efi
bcdedit /store "..\PXEBoot\EFI X86\Boot\BCD" /set {bootmgr} fontpath \boot\fonts
bcdedit /store "..\PXEBoot\EFI X86\Boot\BCD" /set {bootmgr} nointegritychecks yes
bcdedit /store "..\PXEBoot\EFI X86\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize 10




xcopy /e /d "..\Build64\Media\EFI\Microsoft\Boot" "..\PXEBoot\EFI X64\Boot"
xcopy /e /d "..\Build64\Media\Sources" "..\PXEBoot\EFI X64\Sources"
copy "..\Build64\Media\Boot\Boot.sdi" "..\PXEBoot\EFI X64\Boot"
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} Path \bootmgfw.efi
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} fontpath \boot\fonts
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} nointegritychecks yes
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize 10




Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy "%minintx86%\Windows\Boot\PXE\en-US\bootmgr.exe.mui" "..\PXEBoot\BIOS\en-US"
copy "%minintx86%\Windows\Boot\PXE\bootmgr.exe" "..\PXEBoot\BIOS"
copy "%minintx86%\Windows\Boot\PXE\pxeboot.n12" "..\PXEBoot\BIOS\bootmgfw.efi"

copy "%minintx86%\Windows\Boot\EFI\en-US\*.*" "..\PXEBoot\EFI X86\en-US"
copy "%minintx86%\Windows\Boot\EFI\*.efi" "..\PXEBoot\EFI X86"

copy "%minintx64%\Windows\Boot\EFI\en-US\*.*" "..\PXEBoot\EFI X64\en-US"
copy "%minintx64%\Windows\Boot\EFI\*.efi" "..\PXEBoot\EFI X64"

Dism /Unmount-Image /MountDir:"%minintx86%" /discard
Dism /Unmount-Image /MountDir:"%minintx64%" /discard

xcopy /e /d "..\PXEBoot\EFI X64\*.*" "..\PXEBoot\EFI BC"

copy "tune TFTP Window Size.cmd" "..\PXEBoot"

7z a "..\PXE Boot Data.7z" "..\PXEBoot"

@echo off
echo.
echo.
echo.Done!
echo.
echo.4 folders are created (BIOS, EFI X64, EFI X86 and EFI BC) and a 7z Archive
echo.
echo.Note that the start file on all flavours is "bootmgfw.efi"
@echo on