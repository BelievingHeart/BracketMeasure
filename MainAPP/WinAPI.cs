using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


public static class WinAPI
{
    #region 读写ini文件

    [DllImport("kernel32")]
    public static extern int WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string lpDefault, StringBuilder retVal, int size, string filePath);

    #endregion

    #region 窗体以及消息

    public const int SW_HIDE = 0;
    public const int SW_SHOWNORMAL = 1;
    public const int SW_NORMAL = 1;
    public const int SW_SHOWMINIMIZED = 2;
    public const int SW_SHOWMAXIMIZED = 3;
    public const int SW_MAXIMIZE = 3;
    public const int SW_SHOWNOACTIVATE = 4;
    public const int SW_SHOW = 5;
    public const int SW_MINIMIZE = 6;
    public const int SW_SHOWMINNOACTIVE = 7;
    public const int SW_SHOWNA = 8;
    public const int SW_RESTORE = 9;
    public const int SW_SHOWDEFAULT = 10;
    public const int SW_FORCEMINIMIZE = 11;
    public const int SW_MAX = 11;

    [DllImport("user32.dll")]
    public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern int ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll")]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    public const int WM_MOUSEFIRST = 0x0200;
    public const int WM_MOUSEMOVE = 0x0200;
    public const int WM_LBUTTONDOWN = 0x0201;
    public const int WM_LBUTTONUP = 0x0202;
    public const int WM_LBUTTONDBLCLK = 0x0203;
    public const int WM_RBUTTONDOWN = 0x0204;
    public const int WM_RBUTTONUP = 0x0205;
    public const int WM_RBUTTONDBLCLK = 0x0206;
    public const int WM_MBUTTONDOWN = 0x0207;
    public const int WM_MBUTTONUP = 0x0208;
    public const int WM_MBUTTONDBLCLK = 0x0209;
    public const int WM_MOUSEWHEEL = 0x020A;
    public const int WM_XBUTTONDOWN = 0x020B;
    public const int WM_XBUTTONUP = 0x020C;
    public const int WM_XBUTTONDBLCLK = 0x020D;
    public const int WM_MOUSEHWHEEL = 0x020E;
    public const int WM_MOUSELAST = 0x0209;
    public const int WHEEL_DELTA = 120;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

    [DllImport("user32.dll")]
    public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, string lParam);

    [DllImport("user32.dll")]
    public static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll")]
    public static extern int CloseWindow(IntPtr hWnd);

    #endregion

    #region 键盘鼠标

    [DllImport("user32.dll")]
    public static extern short GetKeyState(int nVirtKey);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


    public const uint MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
    public const uint MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
    public const uint MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
    public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */
    public const uint MOUSEEVENTF_RIGHTUP = 0x0010; /* right button up */
    public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020; /* middle button down */
    public const uint MOUSEEVENTF_MIDDLEUP = 0x0040; /* middle button up */
    public const uint MOUSEEVENTF_XDOWN = 0x0080; /* x button down */
    public const uint MOUSEEVENTF_XUP = 0x0100; /* x button down */
    public const uint MOUSEEVENTF_WHEEL = 0x0800; /* wheel button rolled */
    public const uint MOUSEEVENTF_HWHEEL = 0x01000; /* hwheel button rolled */
    public const uint MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000; /* do not coalesce mouse moves */
    public const uint MOUSEEVENTF_VIRTUALDESK = 0x4000; /* map to entire virtual desktop */
    public const uint MOUSEEVENTF_ABSOLUTE = 0x8000; /* absolute move */

    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

    #endregion

    #region 注册热键

    public const uint MOD_ALT = 0x0001;
    public const uint MOD_CONTROL = 0x0002;
    public const uint MOD_SHIFT = 0x0004;
    public const uint MOD_WIN = 0x0008;

    [DllImport("user32.dll")]
    public static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    public static extern int UnregisterHotKey(IntPtr hWnd, int id);
    #endregion

    #region 加载DLL

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpLibFileName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport("kernel32.dll")]
    public static extern int FreeLibrary(IntPtr hLibModule);

    #endregion
}

