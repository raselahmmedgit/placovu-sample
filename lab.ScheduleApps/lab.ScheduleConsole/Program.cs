using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab.ScheduleConsole
{
    class Program
    {
        #region Global Variable Declaration

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        #endregion


        static void Main(string[] args)
        {
            #region Config
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            Console.Title = "Schedule";
            #endregion

            Console.WriteLine("Scheduler Start");

            BootStrapper.Run();

            Console.WriteLine("Scheduler End");
            Console.ReadLine();
        }

        
    }
}
