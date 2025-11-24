call paths.cmd

attrib -r -h -s -a /s "..\PXEBoot"
rmdir /q /s "..\PXEBoot"

mkdir "..\PXEBoot"

mkdir "..\PXEBoot\BIOS"

mkdir "..\PXEBoot\EFI X86"

mkdir "..\PXEBoot\EFI X64"
mkdir "..\PXEBoot\EFI X64\en-US"
mkdir "..\PXEBoot\EFI X64\Boot"
mkdir "..\PXEBoot\EFI X64\Sources"

mkdir "..\PXEBoot\EFI BC"




xcopy /e /d "..\Build64\Media\EFI\Microsoft\Boot" "..\PXEBoot\EFI X64\Boot"
xcopy /e /d "..\Build64\Media\Sources" "..\PXEBoot\EFI X64\Sources"
copy "..\Build64\Media\Boot\Boot.sdi" "..\PXEBoot\EFI X64\Boot"
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {default} description "MiniNT 5 R2"
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} Path \bootmgfw.efi
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} fontpath \boot\fonts
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} nointegritychecks yes
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} displaybootmenu yes
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {bootmgr} timeout 30
bcdedit /store "..\PXEBoot\EFI X64\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize 10




Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

copy "%minintx64%\Windows\Boot\EFI\en-US\*.*" "..\PXEBoot\EFI X64\en-US"
copy "%minintx64%\Windows\Boot\EFI\*.efi" "..\PXEBoot\EFI X64"

Dism /Unmount-Image /MountDir:"%minintx64%" /discard

xcopy /e /d "..\PXEBoot\EFI X64\*.*" "..\PXEBoot\EFI BC"

copy "tune TFTP Window Size.cmd" "..\PXEBoot"

del "..\PXE Boot Data.7z"
7z a "..\PXE Boot Data.7z" "..\PXEBoot"

REM ..\MiniNTUpdateChecksumCalc\bin\Release\MiniNTUpdateChecksumCalc.exe ..\PXEBoot ..\PXEBootFiles.txt

@echo off
echo.
echo.
echo.Done!
echo.
echo.4 folders are created (BIOS, EFI X64, EFI X86 and EFI BC) and a 7z Archive
echo.
echo.Note that the start file on all flavours is "bootmgfw.efi"
@echo on