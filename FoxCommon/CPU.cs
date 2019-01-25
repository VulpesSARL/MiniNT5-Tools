using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Fox.Common
{
    public class CPU
    {
        [DllImport("kernel32.dll")]
        internal static extern void GetNativeSystemInfo(ref SystemInfo lpSystemInfo);

        [DllImport("kernel32.dll")]
        internal static extern void GetSystemInfo(ref SystemInfo lpSystemInfo);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SystemInfo
        {
            public ushort wProcessorArchitecture;
            public ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public UIntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }

        internal const ushort ProcessorArchitectureIntel = 0;
        internal const ushort ProcessorArchitectureIa64 = 6;
        internal const ushort ProcessorArchitectureAmd64 = 9;
        internal const ushort ProcessorArchitectureUnknown = 0xFFFF;

        public enum CPUType
        {
            Intel32,
            EM64T,
            IA64,
            Unknown
        }

        public static CPUType GetCPU()
        {
            SystemInfo SysInfoNative = new SystemInfo();
            SystemInfo SysInfoProcess = new SystemInfo();
            GetNativeSystemInfo(ref SysInfoNative);
            GetSystemInfo(ref SysInfoProcess);

            if (SysInfoNative.wProcessorArchitecture == ProcessorArchitectureUnknown || SysInfoProcess.wProcessorArchitecture == ProcessorArchitectureUnknown)
                return (CPUType.Unknown);
            if (SysInfoProcess.wProcessorArchitecture == ProcessorArchitectureIntel)
                return (CPUType.Intel32);
            if (SysInfoProcess.wProcessorArchitecture == ProcessorArchitectureAmd64)
                return (CPUType.EM64T);
            if (SysInfoProcess.wProcessorArchitecture == ProcessorArchitectureIa64)
                return (CPUType.IA64);
            return (CPUType.Unknown);
        }
    }
}
