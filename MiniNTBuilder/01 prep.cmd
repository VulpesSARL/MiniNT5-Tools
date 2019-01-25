call paths.cmd

attrib -r -h -s -a /s "%minintpath%\Build32\*.*"
attrib -r -h -s -a /s "%minintpath%\Build64\*.*"
rmdir /q /s "%minintpath%\Build32"
rmdir /q /s "%minintpath%\Build64"

attrib -r -h -s -a /s "%minintx64%\*.*"
attrib -r -h -s -a /s "%minintx86%\*.*"
rmdir /q /s "%minintx64%"
rmdir /q /s "%minintx86%"
mkdir "%minintx64%"
mkdir "%minintx86%"

pushd %adk%
call copype amd64 "%minintpath%\Build64"
call copype x86 "%minintpath%\Build32"
popd
