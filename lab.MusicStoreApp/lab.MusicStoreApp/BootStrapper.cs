using lab.MusicStoreApp.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab.MusicStoreApp
{
    public static class BootStrapper
    {
        public static void Run()
        {
            try
            {
                InitializeAndSeedDb();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void InitializeAndSeedDb()
        {
            try
            {
                // Initializes and seeds the database.
                Database.SetInitializer(new DbInitializer());

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