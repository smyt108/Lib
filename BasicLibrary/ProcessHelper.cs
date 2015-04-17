using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace BasicLibrary
{
    public static class ProcessHelpers
    {
        delegate bool EnumChildCallback(int hwnd, ref int lParam);

        const uint OBJID_NATIVEOM = 0xFFFFFFF0;

        static readonly Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");

        [DllImport("User32.dll")]
        static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);

        [DllImport("User32.dll")]
        static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("Oleacc.dll")]
        static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectID, byte[] riid,
                                                     [MarshalAs(UnmanagedType.IDispatch)] ref object ptr);

        static bool EnumChildProc(int hwndChild, ref int lParam)
        {
            StringBuilder buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == "EXCEL7")
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }

        public static dynamic ExcelApplication(this Process process)
        {
            dynamic application = null;
            int hwnd = (int)process.MainWindowHandle;
            if (hwnd != 0)
            {
                int hwndChild = 0;
                EnumChildWindows(hwnd, new EnumChildCallback(EnumChildProc), ref hwndChild);
                if (hwndChild != 0)
                {
                    object ptr = null;
                    try
                    {
                        int hr = AccessibleObjectFromWindow(hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), ref ptr);
                        if (hr >= 0) application = ((dynamic)ptr).Application;
                    }
                    finally
                    {
                        if (ptr != null) Marshal.ReleaseComObject(ptr);
                    }
                }
            }
            return application;
        }
    }
}