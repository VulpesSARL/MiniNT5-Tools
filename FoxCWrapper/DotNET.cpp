#include <windows.h>
#include <msclr\marshal_cppstd.h>
#using <System.dll>
using namespace System;
using namespace System::Text;
using namespace System::Collections::Generic;
using namespace msclr::interop;

#pragma unmanaged

HMODULE WPEUtilDLL=NULL;
extern HINSTANCE GlobalhInstDLL;

DWORD WINAPI SampleApplyCallback(DWORD dwMsgId, WPARAM wParam, LPARAM lParam, PVOID pvIgnored);
int CustomWinPEUtilFunction(const char *Function, WCHAR* Args);
typedef int (CALLBACK *WpeutilFunction)(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpszCmdLine, int nCmdShow);

#pragma managed

namespace Fox
{
	public ref class FoxKeyboardLayout
	{
	public:
		String ^ Name;
		UINT ID;
		virtual String^ ToString() override
		{
			return (Name);
		}
	};

	public ref class FoxCWrapper
	{
	public:
		static String ^ FormatMessage(int hresult)
		{
			LPWSTR errorText = NULL;

			FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_IGNORE_INSERTS,
				NULL, hresult, 0, (LPTSTR)&errorText, 0, NULL);

			if (errorText != NULL)
			{
				String ^ s = gcnew String (errorText);
				LocalFree (errorText);
				return (s);
			}

			return ("");
		}

		static Boolean WPEUtilInit()
		{
			WPEUtilDLL = LoadLibrary (L"wpeutil.dll");
			if (WPEUtilDLL == NULL)
				return(false);
			return(true);
		}

		static void WPEUtilUninit()
		{
			if (WPEUtilDLL!=NULL)
			{
				FreeLibrary (WPEUtilDLL);
				WPEUtilDLL=NULL;
			}
		}

		static int WPEUtilCall(String^ Function, String^ Args)
		{
			if (WPEUtilDLL==NULL)
				return(-1);

			marshal_context^ contextfunction = gcnew marshal_context();
			const char* function = contextfunction->marshal_as<const char*>(Function);

			marshal_context^ contextargs = gcnew marshal_context();
			const WCHAR* args = contextargs->marshal_as<const WCHAR*>(Args);
			int res=-1;
			if (wcslen(args)>0)
			{
				WCHAR* args2 = (WCHAR*)malloc((wcslen(args)*2)+2);
				memcpy (args2,args,(wcslen(args)*2)+2);
				res = CustomWinPEUtilFunction(function,args2);
				free (args2);
			}
			else
			{
				WCHAR* args2 = (WCHAR*)malloc(2);
				args2[0]=0;
				res = CustomWinPEUtilFunction(function,args2);
				free (args2);
			}
			delete contextargs;
			delete contextfunction;
			return(res);
		}

		static List<FoxKeyboardLayout^>^ KeyboardLayoutGetList()
		{
			List<FoxKeyboardLayout^>^% list = gcnew List<FoxKeyboardLayout^>();
			HKEY reg;
			WCHAR LayoutID[512];
			if (RegOpenKeyEx (HKEY_LOCAL_MACHINE, L"SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts",
				0, KEY_READ, &reg)!=ERROR_SUCCESS)
				return (list);

			int count = 0;
			do
			{
				if (RegEnumKey (reg, count, LayoutID, sizeof(LayoutID)/2)==ERROR_SUCCESS)
				{
					HKEY sreg;
					if (RegOpenKeyEx (reg, LayoutID, 0, KEY_READ, &sreg)==ERROR_SUCCESS)
					{
						WCHAR LayoutName[512];
						DWORD sz = sizeof(LayoutName)/2;
						if (RegQueryValueEx (sreg, L"Layout Text", NULL, NULL, (LPBYTE)LayoutName, &sz)==ERROR_SUCCESS)
						{
							FoxKeyboardLayout^ keyb = gcnew FoxKeyboardLayout();
							keyb->ID = Convert::ToUInt32(gcnew String (LayoutID),16);
							keyb->Name = gcnew String(LayoutName);
							list->Add(keyb);
						}
						RegCloseKey (sreg);
					}
				}
				else
				{
					break;
				}
				count++;
			}while(1);

			RegCloseKey (reg);

			return(list);
		}

		static FoxKeyboardLayout^ KeyboardLayoutGetCurrent()
		{
			FoxKeyboardLayout^ keyb = gcnew FoxKeyboardLayout();
			LONG current = (LONG)GetKeyboardLayout(NULL);
			current &= 0xFFFF0000;
			current = current>>16;
			WCHAR Name[1024];
			GetLocaleInfo(MAKELCID(((UINT)current & 0xffffffff), SORT_DEFAULT), LOCALE_SLANGUAGE, Name, sizeof(Name)/2);
			keyb->ID = (UINT)current;
			keyb->Name = gcnew String(Name);
			return (keyb);
		}

		static int KeyboardLayoutSet(UINT ID)
		{
			WCHAR Layout[50];
			swprintf_s (Layout, sizeof(Layout)/2, L"%08X", ID);
			HKL layout = LoadKeyboardLayout(Layout, KLF_ACTIVATE | KLF_SUBSTITUTE_OK);
			if (layout==NULL)
				return(1);
			if (ActivateKeyboardLayout (layout, 0)==0)
				return(2);
			if (SystemParametersInfo (SPI_SETDEFAULTINPUTLANG, 0, &layout, SPIF_SENDCHANGE)==0)
				return(3);
			HWND hwnd;
			hwnd = GetTopWindow(NULL);
			while (hwnd!=NULL)
			{
				PostMessage(hwnd, WM_INPUTLANGCHANGEREQUEST, INPUTLANGCHANGE_SYSCHARSET, (LPARAM)layout);
				hwnd = GetNextWindow(hwnd, GW_HWNDNEXT);
			}
			return(0);
		}


		static void FoxNetworkMap()
		{
			WNetConnectionDialog(NULL, RESOURCETYPE_DISK);
		}

		static void FoxNetworkUnmap(UINT hwnd)
		{
			int res = WNetDisconnectDialog((HWND)hwnd, RESOURCETYPE_DISK);
		}

		static Boolean IsFirmwareEFI()
		{
			FIRMWARE_TYPE fwtype;
			GetFirmwareType(&fwtype);
			if (fwtype == FirmwareTypeUefi)
				return(true);
			return(false);
		}

		static Boolean IsFirmwareLEGACY()
		{
			FIRMWARE_TYPE fwtype;
			GetFirmwareType(&fwtype);
			if (fwtype == FirmwareTypeBios)
				return(true);
			return(false);
		}

		static int DriveGetType(String ^driveletter)
		{
			if (driveletter->Length!=1)
				return(-1);
			marshal_context^ contextdriveletter = gcnew marshal_context();
			const WCHAR* driveletterC = contextdriveletter->marshal_as<const WCHAR*>(driveletter);
			WCHAR FullNTDrive[20];
			swprintf_s (FullNTDrive,sizeof(FullNTDrive)/2, L"\\\\.\\%s:", driveletterC);
			HANDLE h = CreateFile(FullNTDrive, 0, FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
			int res=-1;
			if (h != INVALID_HANDLE_VALUE)
			{
				DISK_GEOMETRY Geom[20];
				DWORD cb;

				if (DeviceIoControl (h, IOCTL_DISK_GET_MEDIA_TYPES, 0, 0,
					Geom, sizeof(Geom), &cb, 0)
					&& cb > 0)
				{
					switch (Geom[0].MediaType)
					{
					case F5_1Pt2_512: // 5.25 1.2MB floppy
					case F5_360_512:  // 5.25 360K  floppy
					case F5_320_512:  // 5.25 320K  floppy
					case F5_320_1024: // 5.25 320K  floppy
					case F5_180_512:  // 5.25 180K  floppy
					case F5_160_512:  // 5.25 160K  floppy
						res = 525;
						break;

					case F3_1Pt44_512: // 3.5 1.44MB floppy
					case F3_2Pt88_512: // 3.5 2.88MB floppy
					case F3_20Pt8_512: // 3.5 20.8MB floppy
					case F3_720_512:   // 3.5 720K   floppy
						res = 350;
						break;

					case RemovableMedia:
						res = 2;
						break;

					case FixedMedia:
						res = 1;
						break;

					default:
						res = 0;
						break;
					}
				}
				else
				{
					res = 0;
				}

				CloseHandle(h);
			}
			else
			{
				res = -1;
			}
			return(res);
		}
	};
}

#pragma unmanaged

int CustomWinPEUtilFunction(const char *Function, WCHAR* Args)
{	
	WpeutilFunction CallFunction = (WpeutilFunction)GetProcAddress(WPEUtilDLL, Function);
	if (CallFunction==NULL)
		return(-1);
	return(CallFunction(GlobalhInstDLL,NULL,Args,SW_SHOW));
}

#pragma managed