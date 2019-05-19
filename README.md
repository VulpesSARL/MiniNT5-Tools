# MiniNT5 Tools

Scripts & Tools to customize Windows PE to my like. Also adds 32 Bit application support to the 64 Bit Windows PE Image.
Really small, ca. 525MiB for the 64 Bit image, ca. 340MiB for the 32 Bit Image.
Can be booted from every media like CD-ROM, USB Sticks and even from Network (PXE).

MiniNT5 is intended for diagnostics, repair & (re-)installation of Windows. (Workstation & Server editions, from Windows 2000 to Windows 10)

Hint: There is no need to disable Secure-Boot in order to boot MiniNT5. Even from PXE.

### Prerequisites

What things you need to build MiniNT

* Windows 10 1709 (x64) or newer
	* with full administrator rights
		* Administrator rights are required because of the DISM commands (Mount WIM, Unmount WIM) and Registry manipulations
* [ADK for Windows 10 Version 1709](https://go.microsoft.com/fwlink/p/?linkid=859206)
	* Assessment and Deployment Kit, nedded for the base Windows PE & additional packages
		* It must be the exact version of the ADK!
* Both x86 and x64 DVDs (or ISO) of Windows 10 Version 1709 (needed for some files, missing from the ADK)
	* Note that the ADK and Windows 10 ISO must be in EN-US language
	* [Windows ISOs here](https://tb.rg-adguard.net/public.php)
* Visual Studio 2017 (I use the Enterprise Edition, [Visual Studio Community Edition](https://visualstudio.microsoft.com/downloads/) confirmed to work)
	* Visual Studio 2013 (v120) Platform Toolset
		* (will work with newer Platform Toolsets, but you need to supply the additional DLLs from Visual C++ Runtime into MiniNT)
	* .NET 4 (the original Windows PE only comes with a small set of .NET 4 Runtime)

### Preparation

Preparing the files:

* Delete all "BlankDir.txt" from all folders
* Extract the contents of both Sources\Install.wim from the DVDs to 2 separate folders (security persmissions does not matter)
* Install ADK, make sure that Windows PE Images & Tools are installed, all other tools (like WinDBG) are not required

### Compiling

Compiling MiniNT:

* Open the project "MiniNT5 Tools.sln" in Visual Studio, and compile the project as Release/Win32 and Release/x64
* Go to the folder "MiniNTBuilder" and adapt "paths.cmd" to your like
* Feel free to modify "MiniNT ID.reg" to your like, not needed
* Copy, if needed, some drivers into the Drivers\x86 and Drivers\x64 folder (in a separate folder for each driver) - these will be picked up automatically
* Open a command prompt with administrative permissions, and run the CMD files from 01 to 99

* when all is success, you see 2 files "MiniNT5 32.iso" and "MiniNT5 64.iso" in the root folder of the project (and a "PXEBoot" folder containig all the files required to boot MiniNT from PXE)

### Preparing for PXE boot

After running the scripts from 01 to 98 successfully, execute "99 Make PXE Boot.cmd"

### Note

All these tools are provided as-is from [Vulpes](https://vulpes.lu).
If you've some questions, contact me [here](https://go.vulpes.lu/contact).

# Tools

### CollectWOW64

Collects all the 32 Bit files needed for MiniNT64, to be able to run 32 bit binaries (only needed for building MiniNT)

### FoxCWrapper

Some common Windows PE commands nicely wrapped for easy usage within .NET (C#)

### FoxCWrapperWIM

Some common WIM functions from Windows (DISM and WIMG-API) nicely wrapped for easy usage within .NET (C#)

### FoxCommon

Some common C# functions to use acros multiple projects

### FoxInstallWIM (aka FoxMultiWIM)

Nice GUI to create & install WIM files
(safe to use within a normal Windows 8 / 10 in production)

### FoxMapNet

simply displays the "Map Network Drive" Window, nothing else
(safe to use within a normal Windows 8 / 10 in production)

### FoxSetKeyboard

Changes the keyboard layout on the fly (does not save the settings)
(safe to use within a normal Windows 8 / 10 in production - restart needed to properly revert to previous settings)

### FoxShell

Small shell, kinda like the Windows NT 3.51 Program Manager
(also does some additional initalizations on MiniNT)

### FoxShellIcon

Small programm to communicate with FoxShell from Batch files to add / remove icons

### FoxUnmapNet

Displays "Disconnect Network Drive" Window, nothing else
(safe to use within a normal Windows 8 / 10 in production)


