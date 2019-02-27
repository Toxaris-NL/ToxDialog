using System;
using System.Runtime.InteropServices;

namespace ToxDialog
{
    /// <summary>
    /// Win32 API needed for LockSystem mode.
    /// </summary>

    internal static class Native
    {
        public const int GENERIC_ALL = 0x10000000;
        public const int DESKTOP_SWITCHDESKTOP = (int)0x100L;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr GetThreadDesktop(int threadId);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr OpenInputDesktop(int flags, [MarshalAs(UnmanagedType.Bool)] bool inherit, int desiredAccess);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr CreateDesktop(string desktop, string device, IntPtr devmode, int flags, int desiredAccess, IntPtr lpsa);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SetThreadDesktop(IntPtr desktop);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SwitchDesktop(IntPtr desktop);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool CloseDesktop(IntPtr desktop);
    }
}