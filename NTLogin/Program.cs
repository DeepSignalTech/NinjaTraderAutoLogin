using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace NTLogin
{
    public class Program
    {
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;       

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);              

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static void ButtonClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
        }

        [STAThread]
        static void Main(string[] args)
        {
            Process ninjaProc = null;
            bool foundNinja = false;
            string userName = string.Empty, passwd = string.Empty;
            string ninjaExe = @"C:\Program Files\NinjaTrader 8\bin\NinjaTrader.exe";

            if (args.Length == 2)
            {
                userName = args[0];
                passwd = args[1];
            }      
            else if (args.Length == 3) 
            {
                userName = args[0];
                passwd = args[1];
                ninjaExe = args[2];
            }

            RECT rctNTPosition = new RECT();
            Process.Start(@ninjaExe);

            while (!foundNinja)
            {
                Process[] processlist = Process.GetProcessesByName("NinjaTrader");
                if (processlist.Length > 0)
                {
                    ninjaProc = processlist[0];
                    foundNinja = true;
                }

                System.Threading.Thread.Sleep(100);
            }

            System.Threading.Thread.Sleep(5000);

            SetForegroundWindow(ninjaProc.MainWindowHandle);                    
            GetWindowRect(ninjaProc.MainWindowHandle, ref rctNTPosition);
            ButtonClick(rctNTPosition.Left + 30, rctNTPosition.Top + 210);

            Clipboard.SetText(passwd);
            SendKeys.SendWait("^v");            
            SendKeys.SendWait("{ENTER}");
        }
    }
}
