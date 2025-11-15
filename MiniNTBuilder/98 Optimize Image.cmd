call paths.cmd

Dism /Export-Image /SourceImageFile:..\Build64\media\sources\boot.wim /SourceIndex:1 /DestinationImageFile:..\Build64\media\sources\boot2.wim

del ..\Build64\media\sources\boot.wim
ren ..\Build64\media\sources\boot2.wim boot.wim


