using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OntrackHealthMailManger.WinService
{
    public class HandleOtherWindow
    {
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr handle);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr handle);

        public static void OntrackHealthMailMangerBackgroundWorker(EventLog eventLogOntrackHealthMail)
        {

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
            eventLogOntrackHealthMail.WriteEntry("Window Open....", EventLogEntryType.Information);
        }
        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = @"C:\Users\Abdur Khan\Documents\Visual Studio 2015\Projects\SSLTest\OntrackHealthMailManger.Win\bin\Debug\OntrackHealthMailManger.Win.exe";
            string name = "OntrackHealthMailManger.Win";
            OpenOntrackHealthMailMangerForm(name, path);
        }
        private static void OpenOntrackHealthMailMangerForm(string name, string path)
        {
            Process[] ps = Process.GetProcessesByName(name);
            if (ps.Length == 0)
            {
                Process process = new Process();
                process.StartInfo.FileName = path;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                var t = process.Id;
                BringToForeground(ps[0].MainWindowHandle);
            }
            else
            {
                BringToForeground(ps[0].MainWindowHandle);
            }
        }
        private static void BringToForeground(IntPtr extHandle)
        {
            if (IsIconic(extHandle))
            {
                ShowWindow(extHandle, SW_RESTORE);
            }
            SetForegroundWindow(extHandle);
        }
    }
}
