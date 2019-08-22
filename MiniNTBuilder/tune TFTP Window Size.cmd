@echo off
IF %1.==. GOTO Err

bcdedit /store "BIOS\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize %1
bcdedit /store "EFI X86\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize %1
bcdedit /store "EFI X64\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize %1
bcdedit /store "EFI BC\Boot\BCD" /set {7619dcc8-fafe-11d9-b411-000476eba25f} ramdisktftpwindowsize %1

GOTO End

:Err
echo. Missing paramater, size from 1 to 16 - 10 is recommended

:End