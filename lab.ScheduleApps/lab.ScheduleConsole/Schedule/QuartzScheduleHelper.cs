using lab.ScheduleConsole.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.ScheduleConsole.Schedule
{
    public class QuartzScheduleHelper
    {
        public void TestSchedule()
        {
            try
            {
                LoggerHelper.WriteLog(("Hello World! I am test scheduler -  :) @raselahmmed : " + DateTime.Now.ToString("F")));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
