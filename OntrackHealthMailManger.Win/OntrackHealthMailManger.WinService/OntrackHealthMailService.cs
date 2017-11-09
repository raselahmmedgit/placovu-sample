using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Net.Mime;
using System.Reflection;


namespace OntrackHealthMailManger.WinService
{
    public partial class OntrackHealthMailService : ServiceBase
    {
        private System.Timers.Timer _myTimer;

        public OntrackHealthMailService()
        {
            InitializeComponent();
            //if (EventLog.SourceExists("Ontrack Health Email Service"))
            //{
            //    EventLog.Delete("OntrackHealthEventLog");
            //    EventLog.DeleteEventSource("Ontrack Health Email Service");
            //}
            if (!EventLog.SourceExists("Ontrack Health Email Service"))
            {
                EventLog.Delete("OntrackHealthEventLog");
                EventLog.DeleteEventSource("Ontrack Health Email Service");
                EventLog.CreateEventSource("Ontrack Health Email Service", "OntrackHealthEventLog");
            }
            EventLogOntrackHealthMail.Source = "Ontrack Health Email Service";
            EventLogOntrackHealthMail.MaximumKilobytes = 2048;
            var t = ConfigurationManager.AppSettings["Timer.Frequency"];
            if (t != null)
                this.OntrackHealthTimer.Interval = Convert.ToInt32(t);

        }
        protected override void OnStart(string[] args)
        {
            EventLogOntrackHealthMail.WriteEntry("Ontrack Health Email Service Started.", EventLogEntryType.Information, args.Length);

            _myTimer = new System.Timers.Timer { Interval = 5000 };
            _myTimer.Elapsed += this.OnTimer;
            _myTimer.Start();
        }
        protected override void OnStop()
        {
            EventLogOntrackHealthMail.WriteEntry("Ontrack Health Email Service OnStop.");
        }
        protected override void OnContinue()
        {
            EventLog.WriteEntry("In OnContinue.");
        }
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.  
            EventLogOntrackHealthMail.WriteEntry("Monitoring the System....", EventLogEntryType.Information);
            Process[] ps = Process.GetProcessesByName("OntrackHealthMailManger.Win");
            if (ps.Length == 0)
            {
                System.Threading.Thread ProcessCreationThread = new System.Threading.Thread(MyThreadFunc);
                ProcessCreationThread.Start();
            }
            //HandleOtherWindow.OntrackHealthMailMangerBackgroundWorker(EventLogOntrackHealthMail);
        }
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public long dwServiceType;
            public ServiceState dwCurrentState;
            public long dwControlsAccepted;
            public long dwWin32ExitCode;
            public long dwServiceSpecificExitCode;
            public long dwCheckPoint;
            public long dwWaitHint;
        };

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        public static void MyThreadFunc()
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            CreateProcessAsUserWrapper.LaunchChildProcess(assemblyPath + "OntrackHealthMailManger.Win.exe");
        }
    }
}
