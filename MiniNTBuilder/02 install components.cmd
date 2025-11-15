call paths.cmd

REM https://learn.microsoft.com/en-us/windows-hardware/manufacture/desktop/winpe-add-packages--optional-components-reference?view=windows-11#how-to-add-optional-components

Dism /Mount-Image /ImageFile:"%minintpath%\Build64\media\sources\boot.wim" /index:1 /MountDir:"%minintx64%"

Dism /Set-ScratchSpace:512 /Image:"%minintx64%"

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

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-StorageWMI.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-StorageWMI_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-RNDIS.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-RNDIS_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-WinReCfg.cab"
Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\en-us\WinPE-WinReCfg_en-us.cab"

Dism /Add-Package /Image:"%minintx64%" /PackagePath:"%ADK%\amd64\WinPE_OCs\WinPE-HSP-Driver.cab"

Dism /Image:"%minintx64%" /enable-feature /featurename=SMB1Protocol
Dism /Image:"%minintx64%" /enable-feature /featurename=SMB1Protocol-client

Dism /Unmount-Image /MountDir:"%minintx64%" /commit

