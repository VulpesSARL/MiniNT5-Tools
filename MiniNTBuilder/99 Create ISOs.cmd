call paths.cmd

oscdimg -lMiniNT5_64 -u2 -bootdata:2#p0,e,b..\build64\fwfiles\etfsboot.com#pEF,e,b..\build64\fwfiles\efisys.bin ..\build64\media "..\MiniNT5 64.iso"
oscdimg -lMiniNT5_32 -u2 -bootdata:2#p0,e,b..\build32\fwfiles\etfsboot.com#pEF,e,b..\build32\fwfiles\efisys.bin ..\build32\media "..\MiniNT5 32.iso"

