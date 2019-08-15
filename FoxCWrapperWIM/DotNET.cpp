#include <windows.h>
#include <msclr\marshal_cppstd.h>
#include "dismapi.h"
#include "wimgapi.h"
#using <System.dll>
using namespace System;
using namespace System::Text;
using namespace System::Collections::Generic;
using namespace msclr::interop;

#pragma unmanaged

DWORD WINAPI SampleApplyCallback(DWORD dwMsgId, WPARAM wParam, LPARAM lParam, PVOID pvIgnored);

#pragma managed

namespace Fox
{
	public enum class DISMCompressionMethod
	{
		none,
		fast,
		max
	};

	public ref struct FoxDismImageInfo
	{
	public:
		UINT  ImageIndex;
		String ^ ImageName;
		String ^ ImageDescription;
		UINT64  ImageSize;
		UINT  Architecture;
		String ^ ProductName;
		String ^ EditionId;
		String ^ InstallationType;
		String ^ Hal;
		String ^ ProductType;
		String ^ ProductSuite;
		UINT  MajorVersion;
		UINT  MinorVersion;
		UINT  SpBuild;
		UINT  SpLevel;
		UINT  Build;
		Boolean  Bootable;
		String ^ SystemRoot;
		List<String^>^ Language;
	};
	public ref class FoxCWrapperDISM
	{
	private:
		static marshal_context^ TempDir = nullptr;
		static const WCHAR* cTempDir = NULL;
	public:
		delegate void FileStatus(String^);
		delegate void PercentStatus(int);
		delegate void Nix(DWORD);
		delegate Boolean CanFileProcess(String^);

		static event FileStatus^ OnFileStatus;
		static event PercentStatus^ OnPercentStatus;
		static event Nix^ OnError;
		static event Nix^ OnRetry;
		static event Nix^ OnInfo;
		static event Nix^ OnWarning;
		static event CanFileProcess^ OnFileProcess;
		static Boolean CancelWIM;
		static Boolean DontApplySecurity = false;
		static Boolean UseAllowFileProcessEvent = false;

		static void CallEvent(DWORD Type, String^Filename, DWORD param)
		{
			switch (Type)
			{
			case WIM_MSG_PROGRESS:
				OnPercentStatus(param);
				break;
			case WIM_MSG_PROCESS:
				OnFileStatus(Filename);
				break;
			case WIM_MSG_ERROR:
				OnError((DWORD)param);
				break;
			case WIM_MSG_RETRY:
				OnRetry((DWORD)param);
				break;
			case WIM_MSG_INFO:
				OnInfo((DWORD)param);
				break;
			case WIM_MSG_WARNING:
				OnWarning((DWORD)param);
				break;
			}
		}

		static bool CallEventAllowFileProcess(String^Filename)
		{
			if (UseAllowFileProcessEvent == true)
				return (OnFileProcess(Filename));
			return(true);
		}

		static HRESULT DISMInit()
		{
			DismLogLevel Log = DismLogErrors;
			return (DismInitialize(Log, NULL, NULL));
		}

		static HRESULT DISMShutdown()
		{
			return (DismShutdown());
		}

		static List<FoxDismImageInfo^>^ DISMGetInfo(String ^ Filename)
		{
			List<FoxDismImageInfo^>^% list = gcnew List<FoxDismImageInfo^>();

			marshal_context^ context = gcnew marshal_context();
			const WCHAR* cfilename = context->marshal_as<const WCHAR*>(Filename);

			UINT ImageInfoCount;
			DismImageInfo *ImageInfo;
			HRESULT hr = DismGetImageInfo(cfilename, &ImageInfo, &ImageInfoCount);
			if (hr != 0)
			{
				delete context;
				return(list);
			}

			for (unsigned int i = 0; i < ImageInfoCount; i++)
			{
				FoxDismImageInfo^ img = gcnew FoxDismImageInfo;
				img->Architecture = ImageInfo[i].Architecture;
				img->EditionId = gcnew String(ImageInfo[i].EditionId);
				img->Hal = gcnew String(ImageInfo[i].Hal);
				img->ImageDescription = gcnew String(ImageInfo[i].ImageDescription);
				img->ImageIndex = ImageInfo[i].ImageIndex;
				img->ImageName = gcnew String(ImageInfo[i].ImageName);
				img->ImageSize = ImageInfo[i].ImageSize;
				img->InstallationType = gcnew String(ImageInfo[i].InstallationType);
				img->Language = gcnew List<String^>();
				for (unsigned int j = 0; j < ImageInfo[i].LanguageCount; j++)
				{
					img->Language->Add(gcnew String(ImageInfo[i].Language[j].Value));
				}
				img->MajorVersion = ImageInfo[i].MajorVersion;
				img->MinorVersion = ImageInfo[i].MinorVersion;
				img->ProductName = gcnew String(ImageInfo[i].ProductName);
				img->ProductSuite = gcnew String(ImageInfo[i].ProductSuite);
				img->ProductType = gcnew String(ImageInfo[i].ProductType);
				img->SpBuild = ImageInfo[i].SpBuild;
				img->SpLevel = ImageInfo[i].SpLevel;
				img->SystemRoot = gcnew String(ImageInfo[i].SystemRoot);
				img->Bootable = ImageInfo[i].Bootable == 0 ? true : false;
				img->Build = ImageInfo[i].Build;
				list->Add(img);
			}

			delete context;
			DismDelete(ImageInfo);
			return (list);
		}

		static String^ DISMDecodeArchitecture(UINT Arch)
		{
			switch (Arch)
			{
			case 0:
				return (gcnew String("x86"));
			case 9:
				return (gcnew String("x64"));
			default:
				return (gcnew String(Arch.ToString()));
			}
		}

		static void SetTempDir(String^Dir)
		{
			if (TempDir == nullptr)
				delete (TempDir);
			TempDir = gcnew marshal_context();
			cTempDir = TempDir->marshal_as<const WCHAR*>(Dir);
		}

		static int WIMApplyImage(String^ Filename, unsigned int Index, String ^Destination)
		{
			marshal_context^ classFilename = gcnew marshal_context();
			const WCHAR* filename = classFilename->marshal_as<const WCHAR*>(Filename);

			marshal_context^ classDestination = gcnew marshal_context();
			const WCHAR* destination = classDestination->marshal_as<const WCHAR*>(Destination);

			WIM_INFO WimInfo;
			HANDLE hWIM;
			HANDLE hImage;
			DWORD CreateResult;
			DWORD res;

			if (WIMRegisterMessageCallback(NULL, (FARPROC)SampleApplyCallback, NULL) == INVALID_CALLBACK_VALUE)
				return (INVALID_CALLBACK_VALUE);

			hWIM = WIMCreateFile(filename, WIM_GENERIC_READ, WIM_OPEN_EXISTING, 0, 0, &CreateResult);
			if (hWIM == NULL)
			{
				delete classDestination;
				delete classFilename;
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			res = WIMGetAttributes(hWIM, &WimInfo, sizeof(WimInfo));
			if (!res)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			if (WimInfo.ImageCount < Index)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(INVALID_CALLBACK_VALUE);
			}

			res = WIMSetTemporaryPath(hWIM, cTempDir);
			if (!res)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			hImage = WIMLoadImage(hWIM, Index);
			if (hImage == NULL)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			CancelWIM = false;

			DWORD Flags = WIM_FLAG_FILEINFO | WIM_FLAG_INDEX;
			if (DontApplySecurity == true)
				Flags |= (WIM_FLAG_NO_DIRACL | WIM_FLAG_NO_FILEACL);
			res = ::WIMApplyImage(hImage, destination, Flags);
			if (!res)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hImage);
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			delete classDestination;
			delete classFilename;
			WIMCloseHandle(hImage);
			WIMCloseHandle(hWIM);
			WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);

			return(0);
		}

		static int WIMCaptureImage(String^ Filename, String^ Source, DISMCompressionMethod Compression)
		{
			marshal_context^ classFilename = gcnew marshal_context();
			const WCHAR* filename = classFilename->marshal_as<const WCHAR*>(Filename);

			marshal_context^ classDestination = gcnew marshal_context();
			const WCHAR* source = classDestination->marshal_as<const WCHAR*>(Source);

			HANDLE hWIM;
			DWORD CreateResult;
			DWORD res;

			if (WIMRegisterMessageCallback(NULL, (FARPROC)SampleApplyCallback, NULL) == INVALID_CALLBACK_VALUE)
				return (INVALID_CALLBACK_VALUE);

			int Compress = 0;
			switch (Compression)
			{
			case DISMCompressionMethod::none:
				Compress = WIM_COMPRESS_NONE; break;
			case DISMCompressionMethod::fast:
				Compress = WIM_COMPRESS_XPRESS; break;
			case DISMCompressionMethod::max:
				Compress = WIM_COMPRESS_LZX; break;
			}

			hWIM = WIMCreateFile(filename, WIM_GENERIC_WRITE, WIM_CREATE_ALWAYS, 0, Compress, &CreateResult);
			if (hWIM == NULL)
			{
				delete classDestination;
				delete classFilename;
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			res = WIMSetTemporaryPath(hWIM, cTempDir);
			if (!res)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			CancelWIM = false;
			UseAllowFileProcessEvent = true;

			DWORD Flags = WIM_FLAG_VERIFY;
			HANDLE hh = ::WIMCaptureImage(hWIM, source, Flags);
			if (!hh)
			{
				delete classDestination;
				delete classFilename;
				WIMCloseHandle(hWIM);
				WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);
				return(GetLastError());
			}

			delete classDestination;
			delete classFilename;
			WIMCloseHandle(hh);
			WIMCloseHandle(hWIM);
			WIMUnregisterMessageCallback(NULL, (FARPROC)SampleApplyCallback);

			return(0);
		}
	};
}

DWORD WINAPI SampleApplyCallback(DWORD dwMsgId, WPARAM wParam, LPARAM lParam, PVOID pvIgnored)
{
	switch (dwMsgId)
	{
	case WIM_MSG_PROGRESS:
		Fox::FoxCWrapperDISM::CallEvent(dwMsgId, gcnew String(""), (DWORD)wParam);
		break;
	case WIM_MSG_PROCESS:
		if (Fox::FoxCWrapperDISM::CancelWIM == true)
			return(WIM_MSG_ABORT_IMAGE);
		Fox::FoxCWrapperDISM::CallEvent(dwMsgId, gcnew String((PWSTR)wParam), 0);
		if (Fox::FoxCWrapperDISM::CallEventAllowFileProcess(gcnew String((PWSTR)wParam)) == false)
		{
			BOOL*pfProcessFile = (PBOOL)lParam;
			*pfProcessFile = false;
		}
		break;
	case WIM_MSG_ERROR:
	case WIM_MSG_RETRY:
	case WIM_MSG_INFO:
	case WIM_MSG_WARNING:
		Fox::FoxCWrapperDISM::CallEvent(dwMsgId, gcnew String(""), (DWORD)lParam);
		break;
	}
	return(WIM_MSG_SUCCESS);
}
