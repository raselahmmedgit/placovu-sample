using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OntrackHealthMailManger.WinDemo
{
    public partial class Form1 : Form
    {
        public const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr handle);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr handle);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            
        }
        public static void MyThreadFunc()
        {
            
        }
    }
}
