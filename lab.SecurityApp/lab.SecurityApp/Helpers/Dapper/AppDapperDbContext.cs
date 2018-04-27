using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Helpers.Dapper
{
    public class AppDapperDbContext
    {
        public SqlConnection SqlConnection;
        public AppDapperDbContext()
        {
            SqlConnection = new SqlConnection(AppDapperDbConfig.ConnectionString);
        }
    }
}