using lab.SecurityApp.Helpers;
using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Helpers.DI;
using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace lab.SecurityApp
{
    public static class BootStrapper
    {
        public static void Run()
        {
            try
            {
                InitializeConnectionString();

                InitializeLog4Net();

                InitializeAndSeedDb();

                SetIocContainer();

                InitializeAutoMapper();
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

        private static void InitializeConnectionString()
        {
            try
            {
                AppDapperDbConfig.ConnectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
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
                new NinjectHelper().Resolve();

                //new AutofacHelper().Resolve();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private static void InitializeAutoMapper()
        {
            try
            {
                AutoMapperHelper.RegisterMaps();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}