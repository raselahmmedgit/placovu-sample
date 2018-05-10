using lab.SecurityApp.MySql.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace lab.SecurityApp.MySql
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start...");

                InitializeAndSeedDb();

                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                // Initializes and seeds the database.
                Database.SetInitializer(new DbInitializer());

                ////MySql ConnectionString
                //string connectionString = ConfigurationManager.AppSettings.Get("AppDbContext.ConnectionString");

                ////MySql ProviderName
                //string providerName = ConfigurationManager.AppSettings.Get("AppDbContext.ProviderName");

                ////Need to Default Connection Factory
                ////MySql Factory
                //Database.DefaultConnectionFactory = new SqlCeConnectionFactory(providerName, "", connectionString);

                DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

                using (var context = new AppDbContext())
                {
                    context.Database.Initialize(force: true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
