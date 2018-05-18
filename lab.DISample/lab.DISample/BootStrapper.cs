using lab.DISample.Helpers.IoC;
using lab.DISample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace lab.DISample
{
    public static class BootStrapper
    {
        public static void Run()
        {
            try
            {
                InitializeLog4Net();

                InitializeAndSeedDb();

                SetIocContainer();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void InitializeLog4Net()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Web.config")));
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

        private static void SetIocContainer()
        {
            try
            {
                UnityConfigHelper.Resolve();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}