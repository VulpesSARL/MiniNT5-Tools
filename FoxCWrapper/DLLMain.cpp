#pragma unmanaged
#include <Windows.h>

HINSTANCE GlobalhInstDLL;

BOOL WINAPI DllMain(
  HINSTANCE hinstDLL,  // handle to DLL module
  DWORD fdwReason,     // reason for calling function
  LPVOID lpvReserved   // reserved
)
{
	if (fdwReason==DLL_PROCESS_ATTACH)
	{
		GlobalhInstDLL=hinstDLL;
		return(TRUE);
	}
}
