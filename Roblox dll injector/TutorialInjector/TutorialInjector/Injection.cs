using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TutorialInjector
{
    class Injection
    {
        public enum Injection_Results
        {
            InvalidDll,
            RobloxNotFound,
            Failed,
            Success
        }

        public sealed class Injector
        {

            static readonly IntPtr PTR_ZERO = (IntPtr)0;

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int CloseHandle(IntPtr hObject);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetModuleHandle(string lpModuleName);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

            static Injector Instance;

            public static Injector GetInstance
            {
                get
                {
                    if(Instance == null)
                    {
                        Instance = new Injector();
                    }
                    return Instance;
                }
            }

            Injector() { }

            public Injection_Results Inject(string sProcessName, string sDllPath)
            {

                uint ProcessId = 0;

                if (!File.Exists(sDllPath))
                {
                    return Injection_Results.InvalidDll;
                }

                Process[] _procs = Process.GetProcesses();
                for (int e = 0; e < _procs.Length; e++)
                {
                    if (_procs[e].ProcessName == sProcessName)
                    {
                        ProcessId = (uint)_procs[e].Id;
                        break;
                    }
                }

                if(ProcessId == 0)
                {
                    return Injection_Results.RobloxNotFound;
                }

                if(!GetInjectionResult(ProcessId, sDllPath))
                {
                    return Injection_Results.Failed;
                }

                return Injection_Results.Success;
            }

            bool GetInjectionResult(uint up, string sDllPath)
            {
                IntPtr _Process = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, up);

                if(_Process == PTR_ZERO)
                {
                    return false;
                }

                IntPtr lpLLAdd = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (lpLLAdd == PTR_ZERO)
                {
                    return false;
                }

                IntPtr lpAdd = VirtualAllocEx(_Process, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);

                if(lpAdd == PTR_ZERO)
                {
                    return false;
                }

                byte[] bytesToWrite = Encoding.ASCII.GetBytes(sDllPath);

                if(WriteProcessMemory(_Process, lpAdd, bytesToWrite, (uint)bytesToWrite.Length, 0) == 0)
                {
                    return false;
                }

                if (CreateRemoteThread(_Process, (IntPtr)null, PTR_ZERO, lpLLAdd, lpAdd, 0, (IntPtr)null) == PTR_ZERO)
                {
                    return false;
                }

                CloseHandle(_Process);
                return true;
            }
        }
    }
}
