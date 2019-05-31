using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Lib_MeasurementUtilities;

namespace MainAPP
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Exceptions handler
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += (sender, eventArgs) =>
            {
                UnhandledExceptionLogger.Log(UVGlue.logFile, (Exception)eventArgs.ExceptionObject, false);
            };
            Application.ThreadException += (sender, eventArgs) =>
            {
                UnhandledExceptionLogger.Log(UVGlue.logFile, eventArgs.Exception, false);
            };

            Process instance = Misc.GetRunningInstance();
            if (null != instance)
            {
                WinAPI.ShowWindowAsync(instance.MainWindowHandle, WinAPI.SW_SHOW);
                WinAPI.SetForegroundWindow(instance.MainWindowHandle);
            }
            else
            {
                UI.FormStarting fs = new UI.FormStarting();
                Application.Run(fs);
                if (fs.DialogResult == DialogResult.OK)
                {
                    UVGlue._formMain = new UI.FormMain();
                    Application.Run(UVGlue._formMain);

                }
            }

        }
    }
}