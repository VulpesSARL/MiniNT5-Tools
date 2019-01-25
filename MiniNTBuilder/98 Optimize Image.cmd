call paths.cmd

Dism /Export-Image /SourceImageFile:..\Build64\media\sources\boot.wim /SourceIndex:1 /DestinationImageFile:..\Build64\media\sources\boot2.wim
Dism /Export-Image /SourceImageFile:..\Build32\media\sources\boot.wim /SourceIndex:1 /DestinationImageFile:..\Build32\media\sources\boot2.wim

del ..\Build64\media\sources\boot.wim
ren ..\Build64\media\sources\boot2.wim boot.wim

del ..\Build32\media\sources\boot.wim
ren ..\Build32\media\sources\boot2.wim boot.wim




