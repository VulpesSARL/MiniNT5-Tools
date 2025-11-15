call paths.cmd

bcdedit /store "..\Build64\media\Boot\BCD" /set {bootmgr} displaybootmenu yes
bcdedit /store "..\Build64\media\Boot\BCD" /set {bootmgr} timeout 30
bcdedit /store "..\Build64\media\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\Build64\media\Boot\BCD" /set {default} description "MiniNT 5 R2"
						
bcdedit /store "..\Build64\media\EFI\Microsoft\Boot\BCD" /set {bootmgr} displaybootmenu yes
bcdedit /store "..\Build64\media\EFI\Microsoft\Boot\BCD" /set {bootmgr} timeout 30
bcdedit /store "..\Build64\media\EFI\Microsoft\Boot\BCD" /set {default} bootmenupolicy Legacy
bcdedit /store "..\Build64\media\EFI\Microsoft\Boot\BCD" /set {default} description "MiniNT 5 R2"



oscdimg -lMiniNT5_64 -u2 -bootdata:2#p0,e,b..\build64\bootbins\etfsboot.com#pEF,e,b..\build64\bootbins\efisys_noprompt.bin ..\build64\media "..\MiniNT5 64.iso"

