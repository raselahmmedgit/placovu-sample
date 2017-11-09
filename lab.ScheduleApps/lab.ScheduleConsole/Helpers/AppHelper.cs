﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.ScheduleConsole.Helpers
{
    public static class AppHelper
    {
        public static string GetAppSettingsString(string keyName)
        {
            try
            {
                return ConfigurationManager.AppSettings.Get(keyName);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static Boolean GetAppSettingsBoolean(string keyName)
        {
            try
            {
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get(keyName));
            }
            catch
            {
                return false;
            }
        }

        public static Int32 GetAppSettingsInteger(string keyName)
        {
            try
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get(keyName));
            }
            catch
            {
                return 0;
            }
        }
    }
}
