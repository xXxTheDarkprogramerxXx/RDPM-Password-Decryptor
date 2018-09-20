using System;
using System.Runtime.InteropServices;

namespace Win32
{
    public class Crypto
    {
        public struct DataBlob
        {
            public int Size;

            public System.IntPtr Data;
        }

        public struct CryptProtectPromptStruct
        {
            public int Size;

            public int Flags;

            public System.IntPtr Window;

            public string Message;
        }

        [System.Runtime.InteropServices.DllImport("crypt32.dll", CharSet = CharSet.Unicode)]
        public static extern bool CryptProtectData(ref Crypto.DataBlob dataIn, string description, ref Crypto.DataBlob optionalEntropy, System.IntPtr reserved, ref Crypto.CryptProtectPromptStruct promptStruct, int flags, out Crypto.DataBlob dataOut);

        [System.Runtime.InteropServices.DllImport("crypt32.dll", CharSet = CharSet.Unicode)]
        public static extern bool CryptUnprotectData(ref Crypto.DataBlob dataIn, string description, ref Crypto.DataBlob optionalEntropy, System.IntPtr reserved, ref Crypto.CryptProtectPromptStruct promptStruct, int flags, out Crypto.DataBlob dataOut);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern void LocalFree(System.IntPtr ptr);
    }
}
