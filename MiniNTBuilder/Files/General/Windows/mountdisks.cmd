@echo off
echo Mounting disks
mountvol /e
devcon /remove storage\*
devcon /rescan
