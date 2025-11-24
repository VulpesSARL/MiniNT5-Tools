# MiniNT5 Tools

Scripts & Tools to customize Windows PE to my like.
Really small, ca. 541MiB for the 64 Bit image.
Can be booted from every media like CD-ROM, USB Sticks and even from Network (PXE).

MiniNT5 is intended for diagnostics, repair & (re-)installation of Windows. (Workstation & Server editions, from Windows 7 to Windows 11)

Hint: There is no need to disable Secure-Boot in order to boot MiniNT5. Even from PXE.

### Prerequisites

What things you need to build MiniNT

* Windows 11 24H2 or newer
	* with full administrator rights
		* Administrator rights are required because of the DISM commands (Mount WIM, Unmount WIM) and Registry manipulations
* [ADK for Windows 11 Version 10.1.26100.2454 (December 2024)](https://go.microsoft.com/fwlink/?linkid=2289980) and the [Windows PE Addon](https://go.microsoft.com/fwlink/?linkid=2289981)
	* Assessment and Deployment Kit, nedded for the base Windows PE & additional packages
		* It must be the exact version of the ADK!
* ISO of Windows 11 24H2 / Updated December 2024 (needed for some files, missing from the ADK)
	* Note that the ADK and Windows 11 ISO must be in EN-US language
	* [Windows ISOs here](https://tb.rg-adguard.net/public.php)
    * ISO SHA256: EE0852439410C62B38E33C5BC3270A8699B07D46CA75601BE6A1C21ABAFA9576 - Name: en-gb_windows_11_consumer_editions_version_24h2_updated_dec_2024_x64_dvd_b146c3af.iso
* Visual Studio 2022 (I use the Enterprise Edition, [Visual Studio Community Edition](https://visualstudio.microsoft.com/downloads/) likely to work)
	* Visual Studio 2022 (v143) Platform Toolset (SDK Version 10.0.26100.0)
	* .NET 4.5 (the original Windows PE only comes with a small set of .NET 4.5 Runtime)

### Preparation

Preparing the files:

* Delete all "BlankDir.txt" from all folders
* Extract the contents of Sources\Install.wim from the DVDs to a separate folder (security persmissions does not matter)
* Install ADK, make sure that Windows PE Images & Tools are installed, all other tools (like WinDBG) are not required

### Compiling

Compiling MiniNT:

* Open the project "MiniNT5 Tools.sln" in Visual Studio, and compile the project as Release/Win32 and Release/x64
* Go to the folder "MiniNTBuilder" and adapt "paths.cmd" to your like
* Feel free to modify "MiniNT ID.reg" to your like, not needed
* Copy, if needed, some drivers into the Drivers\x64 folder (in a separate folder for each driver) - these will be picked up automatically (some drivers are provided)
* Open a command prompt with administrative permissions, and run the CMD files from 01 to 99

* when all is success, you see 1 file "MiniNT5 64.iso" in the root folder of the project (and a "PXEBoot" folder containig all the files required to boot MiniNT from PXE)

### Preparing for PXE boot

After running the scripts from 01 to 98 successfully, execute "99 Make PXE Boot.cmd"

### Note

All these tools are provided as-is from [Vulpes](https://vulpes.lu).
If you've some questions, contact me [here](https://go.vulpes.lu/contact).

# Tools

### FoxCWrapper

Some common Windows PE commands nicely wrapped for easy usage within .NET (C#)

### FoxCWrapperWIM

Some common WIM functions from Windows (DISM and WIMG-API) nicely wrapped for easy usage within .NET (C#)

### FoxCommon

Some common C# functions to use acros multiple projects

### FoxInstallWIM (aka FoxMultiWIM)

Nice GUI to create & install WIM files
(safe to use within a normal Windows 11 in production)

### FoxMapNet

simply displays the "Map Network Drive" Window, nothing else
(safe to use within a normal Windows 11 in production)

### FoxSetKeyboard

Changes the keyboard layout on the fly (does not save the settings)
(safe to use within a normal Windows 11 in production - logout / re-login needed to properly revert to previous settings)

### FoxShell

Small shell, kinda like the Windows NT 3.51 Program Manager
(also does some additional initalizations on MiniNT)

### FoxShellIcon

Small programm to communicate with FoxShell from Batch files to add / remove icons

### FoxUnmapNet

Displays "Disconnect Network Drive" Window, nothing else
(safe to use within a normal Windows 11 in production)

# Screenshots

![First screen when starting MiniNT](/Screenshots/MiniNT01.png?raw=true)
![Fox MultiWIM Tool](/Screenshots/MiniNT02.png?raw=true)
![Fox MultiWIM Tool - Patch Options 1](/Screenshots/MiniNT03.png?raw=true)
![Fox MultiWIM Tool - Patch Options 2](/Screenshots/MiniNT04.png?raw=true)
![Functional Explorer Interface](/Screenshots/MiniNT05.png?raw=true)
![Some tools](/Screenshots/MiniNT06.png?raw=true)
![Command Prompt](/Screenshots/MiniNT07.png?raw=true)

# Video Demo

[Video Demo on YouTube](https://youtu.be/CHTeJ7jAMo8)
