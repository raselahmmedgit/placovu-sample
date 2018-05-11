using System;
using System.Configuration;
using System.Web;

namespace lab.MusicStoreApp.Utility
{
    public static class SiteConfigurationReader
    {
        public static string WebRoot
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    if (HttpContext.Current.Request.ApplicationPath != "/")
                    {
                        return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
                    }
                    else
                    {
                        return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
                    }
                }
                else
                {
                    string webRoot = GetAppSettingsString("WebRoot");
                    if (!String.IsNullOrEmpty(webRoot))
                    {
                        return webRoot;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
        }

        private static string _databaseConnectionString = string.Empty;

        public static string DatabaseConnectionString
        {
            get
            {
                if (!String.IsNullOrEmpty(_databaseConnectionString))
                {
                    _databaseConnectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
                }
                return _databaseConnectionString;
            }
        }

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

        public static Int32 GetAppSettingsInteger(string keyName)
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get(keyName));
            }
            catch
            {
                return 0;
            }
        }

        public static bool GetAppSettingsBool(string keyName)
        {
            try
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings.Get(keyName));
            }
            catch
            {
                return false;
            }
        }

        public static String ActiveLanguages
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ActiveLanguages").ToString();
            }
        }
    }
}