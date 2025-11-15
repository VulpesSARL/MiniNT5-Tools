call paths.cmd

REM
REM Needed: OSCDIMG from ADK 10.1.26100.2454 (December 2024) (from Main Package)
REM Needed: Windows PE Addon from ADK 10.1.26100.2454 (December 2024)
REM
REM WARNING: you may need to run this file in Deployment and Imaging Tools Environment (found in the Start Menu) [as ADMIN!] not in plain CMD!
REM

attrib -r -h -s -a /s "%minintpath%\Build64\*.*"
rmdir /q /s "%minintpath%\Build64"

attrib -r -h -s -a /s "%minintx64%\*.*"
rmdir /q /s "%minintx64%"
mkdir "%minintx64%"

pushd %adk%
call copype amd64 "%minintpath%\Build64"
popd
