using lab.SBThemeApps.Helpers;
using lab.SBThemeApps.Helpers.DI;
using lab.SBThemeApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace lab.SBThemeApps
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
                //NinjectConfig.Resolve();
                //UnityConfig.RegisterComponents();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}