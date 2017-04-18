using System;
using System.IO;
using System.Timers;
using System.ServiceProcess;

namespace WindowsServiceDemo
{
    public partial class MyService : ServiceBase
    {
        private System.Timers.Timer aTimer;

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(timer1_Tick); 
            aTimer.Interval = 60 * 1000;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        protected void timer1_Tick(object source, ElapsedEventArgs e)
        {

        }

        private void WriteFile(string _filePath, string TOEXCELLR)
        {
            if (CreateXmlFile(_filePath))
            {
                using (StreamWriter fs = new StreamWriter(_filePath, true, System.Text.Encoding.UTF8))
                {
                    fs.Write(TOEXCELLR);
                }
            }
        }

        private static Boolean CreateXmlFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    using (StreamWriter xmlfs = new StreamWriter(filepath, true, System.Text.Encoding.UTF8))
                    {
                        xmlfs.Write("");
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
