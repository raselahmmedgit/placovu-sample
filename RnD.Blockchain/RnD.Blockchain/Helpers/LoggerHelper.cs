using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.Blockchain.Helpers
{
    public class LoggerHelper
    {
        static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void ErrorLog()
        {
        }

        public static void ErrorLog(Exception ex)
        {
            _logger.Error("Error Log: ", ex);
        }

        public static void InfoLog(Exception ex)
        {
            _logger.Info("Info Log: ", ex);
        }

        public static void InfoLog(string info)
        {
            _logger.Info(info);
        }
    }
}