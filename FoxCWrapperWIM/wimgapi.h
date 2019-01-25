/****************************************************************************\

    WIMGAPI.H

    Copyright (c) Microsoft Corporation.
    All rights reserved.

\****************************************************************************/

#ifndef _WIMGAPI_H_
#define _WIMGAPI_H_

#ifdef __cplusplus
extern "C" {
#endif

//
// Defined Value(s):
//

// WIMCreateFile:
//
#define WIM_GENERIC_READ            GENERIC_READ
#define WIM_GENERIC_WRITE           GENERIC_WRITE
#define WIM_GENERIC_MOUNT           GENERIC_EXECUTE

#define WIM_CREATE_NEW              CREATE_NEW
#define WIM_CREATE_ALWAYS           CREATE_ALWAYS
#define WIM_OPEN_EXISTING           OPEN_EXISTING
#define WIM_OPEN_ALWAYS             OPEN_ALWAYS

typedef enum
{
    WIM_COMPRESS_NONE = 0,
    WIM_COMPRESS_XPRESS,
    WIM_COMPRESS_LZX,
    WIM_COMPRESS_LZMS
};

typedef enum
{
    WIM_CREATED_NEW = 0,
    WIM_OPENED_EXISTING
};

// WIMCreateFile, WIMCaptureImage, WIMApplyImage, WIMMountImageHandle flags:
//
#define WIM_FLAG_RESERVED           0x00000001
#define WIM_FLAG_VERIFY             0x00000002
#define WIM_FLAG_INDEX              0x00000004
#define WIM_FLAG_NO_APPLY           0x00000008
#define WIM_FLAG_NO_DIRACL          0x00000010
#define WIM_FLAG_NO_FILEACL         0x00000020
#define WIM_FLAG_SHARE_WRITE        0x00000040
#define WIM_FLAG_FILEINFO           0x00000080
#define WIM_FLAG_NO_RP_FIX          0x00000100
#define WIM_FLAG_MOUNT_READONLY     0x00000200
#define WIM_FLAG_MOUNT_FAST         0x00000400
#define WIM_FLAG_MOUNT_LEGACY       0x00000800

// WIMGetMountedImageList flags
//
#define WIM_MOUNT_FLAG_MOUNTED              0x00000001
#define WIM_MOUNT_FLAG_MOUNTING             0x00000002
#define WIM_MOUNT_FLAG_REMOUNTABLE          0x00000004
#define WIM_MOUNT_FLAG_INVALID              0x00000008
#define WIM_MOUNT_FLAG_NO_WIM               0x00000010
#define WIM_MOUNT_FLAG_NO_MOUNTDIR          0x00000020
#define WIM_MOUNT_FLAG_MOUNTDIR_REPLACED    0x00000040
#define WIM_MOUNT_FLAG_READWRITE            0x00000100

// WIMCommitImageHandle flags
//
#define WIM_COMMIT_FLAG_APPEND      0x00000001

// WIMSetReferenceFile
//
#define WIM_REFERENCE_APPEND        0x00010000
#define WIM_REFERENCE_REPLACE       0x00020000

// WIMExportImage
//
#define WIM_EXPORT_ALLOW_DUPLICATES   0x00000001
#define WIM_EXPORT_ONLY_RESOURCES     0x00000002
#define WIM_EXPORT_ONLY_METADATA      0x00000004
#define WIM_EXPORT_VERIFY_SOURCE      0x00000008
#define WIM_EXPORT_VERIFY_DESTINATION 0x00000010

// WIMRegisterMessageCallback:
//
#define INVALID_CALLBACK_VALUE      0xFFFFFFFF

// WIMCopyFile
//
#define WIM_COPY_FILE_RETRY         0x01000000

// WIMDeleteImageMounts
//
#define WIM_DELETE_MOUNTS_ALL       0x00000001

// WIMRegisterLogfile
//
#define WIM_LOGFILE_UTF8            0x00000001

// WIMMessageCallback Notifications:
//
typedef enum
{
    WIM_MSG = WM_APP + 0x1476,
    WIM_MSG_TEXT,
    WIM_MSG_PROGRESS,
    WIM_MSG_PROCESS,
    WIM_MSG_SCANNING,
    WIM_MSG_SETRANGE,
    WIM_MSG_SETPOS,
    WIM_MSG_STEPIT,
    WIM_MSG_COMPRESS,
    WIM_MSG_ERROR,
    WIM_MSG_ALIGNMENT,
    WIM_MSG_RETRY,
    WIM_MSG_SPLIT,
    WIM_MSG_FILEINFO,
    WIM_MSG_INFO,
    WIM_MSG_WARNING,
    WIM_MSG_CHK_PROCESS,
    WIM_MSG_WARNING_OBJECTID,
    WIM_MSG_STALE_MOUNT_DIR,
    WIM_MSG_STALE_MOUNT_FILE,
    WIM_MSG_MOUNT_CLEANUP_PROGRESS,
    WIM_MSG_CLEANUP_SCANNING_DRIVE,
    WIM_MSG_IMAGE_ALREADY_MOUNTED,
    WIM_MSG_CLEANUP_UNMOUNTING_IMAGE,
    WIM_MSG_QUERY_ABORT,
    WIM_MSG_IO_RANGE_START_REQUEST_LOOP,
    WIM_MSG_IO_RANGE_END_REQUEST_LOOP,
    WIM_MSG_IO_RANGE_REQUEST,
    WIM_MSG_IO_RANGE_RELEASE,
    WIM_MSG_VERIFY_PROGRESS,
    WIM_MSG_COPY_BUFFER,
    WIM_MSG_METADATA_EXCLUDE,
    WIM_MSG_GET_APPLY_ROOT,
    WIM_MSG_MDPAD,
    WIM_MSG_STEPNAME
};

//
// WIMMessageCallback Return codes:
//
#define WIM_MSG_SUCCESS          ERROR_SUCCESS
#define WIM_MSG_DONE             0xFFFFFFF0
#define WIM_MSG_SKIP_ERROR       0xFFFFFFFE
#define WIM_MSG_ABORT_IMAGE      0xFFFFFFFF

//
// WIM_INFO dwFlags values:
//
#define WIM_ATTRIBUTE_NORMAL        0x00000000
#define WIM_ATTRIBUTE_RESOURCE_ONLY 0x00000001
#define WIM_ATTRIBUTE_METADATA_ONLY 0x00000002
#define WIM_ATTRIBUTE_VERIFY_DATA   0x00000004
#define WIM_ATTRIBUTE_RP_FIX        0x00000008
#define WIM_ATTRIBUTE_SPANNED       0x00000010
#define WIM_ATTRIBUTE_READONLY      0x00000020

//
// The WIM_INFO structure used by WIMGetAttributes:
//
typedef struct _WIM_INFO
{
    WCHAR  WimPath[MAX_PATH];
    GUID   Guid;
    DWORD  ImageCount;
    DWORD  CompressionType;
    USHORT PartNumber;
    USHORT TotalParts;
    DWORD  BootIndex;
    DWORD  WimAttributes;
    DWORD  WimFlagsAndAttr;
} WIM_INFO, *PWIM_INFO, *LPWIM_INFO;

//
// The WIM_MOUNT_LIST structure used for getting the list of mounted images.
//
typedef struct _WIM_MOUNT_LIST
{
    WCHAR  WimPath[MAX_PATH];
    WCHAR  MountPath[MAX_PATH];
    DWORD  ImageIndex;
    BOOL   MountedForRW;
} WIM_MOUNT_LIST, *PWIM_MOUNT_LIST, *LPWIM_MOUNT_LIST,
  WIM_MOUNT_INFO_LEVEL0, *PWIM_MOUNT_INFO_LEVEL0, LPWIM_MOUNT_INFO_LEVEL0;

//
// Define new WIM_MOUNT_INFO_LEVEL1 structure with additional data...
//
typedef struct _WIM_MOUNT_INFO_LEVEL1
{
    WCHAR  WimPath[MAX_PATH];
    WCHAR  MountPath[MAX_PATH];
    DWORD  ImageIndex;
    DWORD  MountFlags;
} WIM_MOUNT_INFO_LEVEL1, *PWIM_MOUNT_INFO_LEVEL1, *LPWIM_MOUNT_INFO_LEVEL1;

//
// Define enumeration for WIMGetMountedImageInfo to determine structure to use...
//
typedef enum _MOUNTED_IMAGE_INFO_LEVELS 
{
    MountedImageInfoLevel0,
    MountedImageInfoLevel1,
    MountedImageInfoLevelInvalid
} MOUNTED_IMAGE_INFO_LEVELS;

//
// An abstract type implemented by the caller when using File I/O callbacks.
//
typedef VOID * PFILEIOCALLBACK_SESSION;

//
// The WIM_IO_RANGE_CALLBACK structure is used in conjunction with the
// FileIOCallbackReadFile callback and the WIM_MSG_IO_RANGE_REQUEST and
// WIM_MSG_IO_RANGE_RELEASE message callbacks.  A pointer to a
// WIM_IO_RANGE_REQUEST is passed in WPARAM to the callback for both messages.
//
typedef struct _WIM_IO_RANGE_CALLBACK
{
    //
    // The callback session that corresponds to the file that is being queried.
    //
    PFILEIOCALLBACK_SESSION pSession;

    // Filled in by WIMGAPI for both messages:
    LARGE_INTEGER Offset, Size;

    // Filled in by the callback for WIM_MSG_IO_RANGE_REQUEST (set to TRUE to
    // indicate data in the specified range is available, and FALSE to indicate
    // it is not yet available):
    BOOL Available;
} WIM_IO_RANGE_CALLBACK, *PWIM_IO_RANGE_CALLBACK;


//
// Abstract (opaque) type for WIM files used with
// WIMEnumImageFiles API
//
typedef VOID * PWIM_ENUM_FILE;


#if defined(__cplusplus)
typedef struct _WIM_FILE_FIND_DATA : public _WIN32_FIND_DATAW
{
#else
typedef struct _WIM_FILE_FIND_DATA
{
    WIN32_FIND_DATAW;
#endif

    BYTE bHash[20];
    PSECURITY_DESCRIPTOR pSecurityDescriptor;
    PWSTR *ppszAlternateStreamNames;
    PBYTE pbReparseData;
    DWORD cbReparseData;
} WIM_FIND_DATA, *PWIM_FIND_DATA;

//
// Exported Function Prototypes:
//
HANDLE
WINAPI
WIMCreateFile(
    _In_      PCWSTR pszWimPath,
    _In_      DWORD  dwDesiredAccess,
    _In_      DWORD  dwCreationDisposition,
    _In_      DWORD  dwFlagsAndAttributes,
    _In_      DWORD  dwCompressionType,
    _Out_opt_ PDWORD pdwCreationResult
    );

BOOL
WINAPI
WIMCloseHandle(
    _In_ HANDLE hObject
    );

BOOL
WINAPI
WIMSetTemporaryPath(
    _In_ HANDLE hWim,
    _In_ PCWSTR pszPath
    );

BOOL
WINAPI
WIMSetReferenceFile(
    _In_ HANDLE hWim,
    _In_ PCWSTR pszPath,
    _In_ DWORD  dwFlags
    );

BOOL
WINAPI
WIMSplitFile(
    _In_    HANDLE         hWim,
    _In_    PCWSTR         pszPartPath,
    _Inout_ PLARGE_INTEGER pliPartSize,
    _In_    DWORD          dwFlags
    );

BOOL
WINAPI
WIMExportImage(
    _In_ HANDLE hImage,
    _In_ HANDLE hWim,
    _In_ DWORD  dwFlags
    );

BOOL
WINAPI
WIMDeleteImage(
    _In_ HANDLE hWim,
    _In_ DWORD  dwImageIndex
    );

DWORD
WINAPI
WIMGetImageCount(
    _In_ HANDLE hWim
    );

BOOL
WINAPI
WIMGetAttributes(
    _In_                    HANDLE     hWim,
    _Out_writes_bytes_(cbWimInfo) PWIM_INFO  pWimInfo,
    _In_                    DWORD      cbWimInfo
    );

BOOL
WINAPI
WIMSetBootImage(
    _In_ HANDLE hWim,
    _In_ DWORD  dwImageIndex
    );

HANDLE
WINAPI
WIMCaptureImage(
    _In_ HANDLE hWim,
    _In_ PCWSTR pszPath,
    _In_ DWORD  dwCaptureFlags
    );

HANDLE
WINAPI
WIMLoadImage(
    _In_ HANDLE hWim,
    _In_ DWORD  dwImageIndex
    );

BOOL
WINAPI
WIMApplyImage(
    _In_     HANDLE hImage,
    _In_opt_ PCWSTR pszPath,
    _In_     DWORD  dwApplyFlags
    );

BOOL
WINAPI
WIMGetImageInformation(
    _In_  HANDLE hImage,
    __typefix(PWSTR*) __deref_out_ecount_z(*pcbImageInfo/2) PVOID *ppvImageInfo,
    _Out_ PDWORD pcbImageInfo
    );

BOOL
WINAPI
WIMSetImageInformation(
    _In_                     HANDLE hImage,
    _In_reads_bytes_(cbImageInfo) PVOID  pvImageInfo,
    _In_                     DWORD  cbImageInfo
    );

DWORD
WINAPI
WIMGetMessageCallbackCount(
    _In_opt_ HANDLE hWim
    );

DWORD
WINAPI
WIMRegisterMessageCallback(
    _In_opt_ HANDLE  hWim,
    _In_     FARPROC fpMessageProc,
    _In_opt_ PVOID   pvUserData
    );

BOOL
WINAPI
WIMUnregisterMessageCallback(
    _In_opt_ HANDLE  hWim,
    _In_opt_ FARPROC fpMessageProc
    );

DWORD
WINAPI
WIMMessageCallback(
    _In_ DWORD  dwMessageId,
    _In_ WPARAM wParam,
    _In_ LPARAM lParam,
    _In_ PVOID  pvUserData
    );

BOOL
WINAPI
WIMCopyFile(
    _In_     PCWSTR             pszExistingFileName,
    _In_     PCWSTR             pszNewFileName,
    _In_opt_ LPPROGRESS_ROUTINE pProgressRoutine,
    _In_opt_ PVOID              pvData,
    _In_opt_ PBOOL              pbCancel,
    _In_     DWORD              dwCopyFlags
    );

BOOL
WINAPI
WIMMountImage(
    _In_     PCWSTR pszMountPath,
    _In_     PCWSTR pszWimFileName,
    _In_     DWORD  dwImageIndex,
    _In_opt_ PCWSTR pszTempPath
    );

BOOL
WINAPI
WIMMountImageHandle(
    _In_ HANDLE hImage,
    _In_ PCWSTR pszMountPath,
    _In_ DWORD  dwMountFlags
    );

BOOL
WINAPI
WIMRemountImage(
    _In_ PCWSTR pszMountPath,
    _In_ DWORD  dwFlags
    );

BOOL
WINAPI
WIMCommitImageHandle(
    _In_      HANDLE  hImage,
    _In_      DWORD   dwCommitFlags,
    _Out_opt_ PHANDLE phNewImageHandle
    );

BOOL
WINAPI
WIMUnmountImage(
    _In_     PCWSTR pszMountPath,
    _In_opt_ PCWSTR pszWimFileName,
    _In_     DWORD  dwImageIndex,
    _In_     BOOL   bCommitChanges
    );

BOOL
WINAPI
WIMUnmountImageHandle(
    _In_ HANDLE hImage,
    _In_ DWORD  dwUnmountFlags
    );

BOOL
WINAPI
WIMGetMountedImages(
    _Out_writes_bytes_opt_(*pcbMountList) PWIM_MOUNT_LIST pMountList,
    _Inout_                         PDWORD          pcbMountListLength
    );

BOOL
WINAPI
WIMGetMountedImageInfo(
    _In_ MOUNTED_IMAGE_INFO_LEVELS fInfoLevelId,
    _Out_ PDWORD pdwImageCount,
    _Out_writes_bytes_opt_(cbMountInfoLength) PVOID  pMountInfo,
    _In_ DWORD  cbMountInfoLength,
    _Out_ PDWORD pcbReturnLength
    );

BOOL
WINAPI
WIMGetMountedImageInfoFromHandle(
    _In_ HANDLE hImage,
    _In_ MOUNTED_IMAGE_INFO_LEVELS fInfoLevelId,
    _Out_writes_bytes_opt_(cbMountInfoLength) PVOID pMountInfo,
    _In_ DWORD cbMountInfoLength,
    _Out_ PDWORD pcbReturnLength
    );

BOOL
WINAPI
WIMGetMountedImageHandle(
    _In_  PCWSTR  pszMountPath,
    _In_  DWORD   dwFlags,
    _Out_ PHANDLE phWimHandle,
    _Out_ PHANDLE phImageHandle 
    );

BOOL
WINAPI
WIMDeleteImageMounts(
    _In_ DWORD dwDeleteFlags
    );

BOOL
WINAPI
WIMRegisterLogFile(
    _In_ PCWSTR pszLogFile,
    _In_ DWORD  dwFlags
    );

BOOL
WINAPI
WIMUnregisterLogFile(
    _In_ PCWSTR pszLogFile
    );

BOOL
WINAPI
WIMExtractImagePath(
    _In_ HANDLE hImage,
    _In_ PCWSTR pszImagePath,
    _In_ PCWSTR pszDestinationPath,
    _In_ DWORD  dwExtractFlags
    );

HANDLE
WINAPI
WIMFindFirstImageFile(
    _In_ HANDLE            hImage,
    _In_ PCWSTR            pwszFilePath,
    _Out_ PWIM_FIND_DATA   pFindFileData
    );

BOOL
WINAPI
WIMFindNextImageFile(
    _In_  HANDLE           hFindFile,
    _Out_ PWIM_FIND_DATA   pFindFileData
    );


//
// API for fast enumeration of image files
//
typedef
HRESULT
(CALLBACK * WIMEnumImageFilesCallback)(
    _In_ PWIM_FIND_DATA     pFindFileData, 
    _In_ PWIM_ENUM_FILE     pEnumFile, 
    _In_opt_ PVOID          pEnumContext
    );

BOOL
WINAPI
WIMEnumImageFiles(
    _In_ HANDLE                     hImage, 
    _In_opt_ PWIM_ENUM_FILE         pEnumFile, 
    _In_ WIMEnumImageFilesCallback  fpEnumImageCallback, 
    _In_opt_ PVOID                  pEnumContext
    );


HANDLE
WINAPI
WIMCreateImageFile(
    _In_ HANDLE    hImage,
    _In_ PCWSTR    pwszFilePath,
    _In_ DWORD     dwDesiredAccess,
    _In_ DWORD     dwCreationDisposition,
    _In_ DWORD     dwFlagsAndAttributes
    );

BOOL
WINAPI
WIMReadImageFile(
    _In_                                            HANDLE        hImgFile,
    _Out_writes_bytes_to_(dwBytesToRead, *pdwBytesRead) PBYTE         pbBuffer,
    _In_                                            DWORD         dwBytesToRead,
    _Out_opt_                                       PDWORD        pdwBytesRead,
    _Inout_                                         LPOVERLAPPED  lpOverlapped
    );

BOOL
WINAPI
WIMInitFileIOCallbacks(
    _In_opt_ PVOID pCallbacks
    );

BOOL
WINAPI
WIMSetFileIOCallbackTemporaryPath(
    _In_opt_ PCWSTR pszPath
    );

//
// File I/O callback prototypes
//

typedef
PFILEIOCALLBACK_SESSION
(CALLBACK * FileIOCallbackOpenFile)(
    _In_ PCWSTR pszFileName
    );

typedef
BOOL
(CALLBACK * FileIOCallbackCloseFile)(
    _In_ PFILEIOCALLBACK_SESSION hFile
    );

typedef
BOOL
(CALLBACK * FileIOCallbackReadFile)(
    _In_ PFILEIOCALLBACK_SESSION hFile,
    _Out_ PVOID pBuffer,
    _In_ DWORD nNumberOfBytesToRead,
    _Out_ PDWORD pNumberOfBytesRead,
    _Inout_ LPOVERLAPPED pOverlapped
    );

typedef
BOOL
(CALLBACK * FileIOCallbackSetFilePointer)(
    _In_ PFILEIOCALLBACK_SESSION hFile,
    _In_ LARGE_INTEGER liDistanceToMove,
    _Out_ PLARGE_INTEGER pNewFilePointer,
    _In_ DWORD dwMoveMethod
    );

typedef
BOOL
(CALLBACK * FileIOCallbackGetFileSize)(
    _In_ HANDLE hFile,
    _Out_ PLARGE_INTEGER pFileSize
    );

typedef struct _SFileIOCallbackInfo
{
    FileIOCallbackOpenFile       pfnOpenFile;
    FileIOCallbackCloseFile      pfnCloseFile;
    FileIOCallbackReadFile       pfnReadFile;
    FileIOCallbackSetFilePointer pfnSetFilePointer;
    FileIOCallbackGetFileSize    pfnGetFileSize;
} SFileIOCallbackInfo;

#ifdef __cplusplus
}
#endif

#endif // _WIMGAPI_H_
