using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps.Helpers
{
    public class ConnectionStringHelper
    {
        private ConnectionStringHelper() { }
        private static ConnectionStringHelper _connectionStringHelper = null;
        private string _connectionString = null;

        private static string GetConnectionString()
        {
            ////Build an SQL connection string
            //SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder(SiteConfigurationReader.ConnectionString);

            ////Build an Entity Framework connection string
            //EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder()
            //{
            //    Provider = SiteConfigurationReader.ConnectionStringProvider,
            //    ProviderConnectionString = sqlConnectionString.ToString()
            //};

            ////EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder(SiteConfigurationReader.ConnectionString);

            //return entityConnectionStringBuilder.ConnectionString;

            return SiteConfigurationReader.ConnectionString;
        }

        private static bool IsUseEncryption()
        {
            if (ConfigurationManager.AppSettings.Get("UseEncryption") != null && Convert.ToBoolean(ConfigurationManager.AppSettings.Get("UseEncryption")) == true)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (IsUseEncryption())
                {
                    return "name=AppDbContext";
                }

                if (_connectionStringHelper == null)
                {
                    _connectionStringHelper = new ConnectionStringHelper { _connectionString = ConnectionStringHelper.GetConnectionString() };
                    return _connectionStringHelper._connectionString;
                }
                else
                    return _connectionStringHelper._connectionString;
            }
        }

        
    }
}