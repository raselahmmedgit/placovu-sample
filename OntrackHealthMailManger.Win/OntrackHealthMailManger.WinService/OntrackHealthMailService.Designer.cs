namespace OntrackHealthMailManger.WinService
{
    partial class OntrackHealthMailService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EventLogOntrackHealthMail = new System.Diagnostics.EventLog();
            this.OntrackHealthTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EventLogOntrackHealthMail)).BeginInit();
            // 
            // OntrackHealthTimer
            // 
            this.OntrackHealthTimer.Interval = 5000;
            // 
            // OntrackHealthMailService
            // 
            this.ServiceName = "OntrackHealthMailService";
            ((System.ComponentModel.ISupportInitialize)(this.EventLogOntrackHealthMail)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog EventLogOntrackHealthMail;
        private System.Windows.Forms.Timer OntrackHealthTimer;
    }
}
