using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps.Helpers
{
    public class SiteConfigurationReader
    {
        public static string SqlConnectionKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("AppDbContext").ToString();
            }
        }

        public static string ConnectionString
        {
            get
            {
                string encryptConnectionString = GetAppSettingsString("ConStr");

                string decryptConnectionString = CryptographyHelper.Decrypt(encryptConnectionString);

                return decryptConnectionString;
            }
        }

        public static string ConnectionStringProvider
        {
            get
            {
                return GetAppSettingsString("ConStrProvider");
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

    }
}