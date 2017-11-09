using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OntrackHealthMailManger.Win
{
    public partial class Form1 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CP_NOCLOSE = 0x200;
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE;
                return myCp;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.OnFormClosing(e);
            WindowState = FormWindowState.Normal;
            this.Activate();
        }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
