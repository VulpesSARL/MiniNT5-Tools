call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=Win32
timeout 30

call msbuild "..\MiniNT5 Tools.sln" /property:Configuration=Release /property:Platform=x64
timeout 30