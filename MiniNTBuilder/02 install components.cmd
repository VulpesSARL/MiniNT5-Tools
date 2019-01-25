call paths.cmd

Dism /Mount-Image /ImageFile:"%minintpath%\Build32\media\sources\boot.wim" /index:1 /MountDir:"%minintx86%"
Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

Dism /Set-ScratchSpace:256 /Image:"%minintx86%"
Dism /Set-ScratchSpace:256 /Image:"%minintx64%"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-Fonts-Legacy.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-MDAC.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-MDAC_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-wmi.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-wmi_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-netfx.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-netfx_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-dot3svc.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-dot3svc_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-Scripting.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-Scripting_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-SecureStartup.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-SecureStartup_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-EnhancedStorage.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-EnhancedStorage_en-us.cab"




Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-Fonts-Legacy.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-MDAC.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-MDAC_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-wmi.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-wmi_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-netfx.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-netfx_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-dot3svc.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-dot3svc_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-Scripting.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-Scripting_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-SecureStartup.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-SecureStartup_en-us.cab"

Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\WinPE-EnhancedStorage.cab"
Dism /Add-Package /Image:"%minintx86%" /PackagePath:"%ADK%\x86\WinPE_OCs\en-us\WinPE-EnhancedStorage_en-us.cab"


Dism /Unmount-Image /MountDir:"%minintx86%" /commit
Dism /Unmount-Image /MountDir:"%minintx64%" /commit

