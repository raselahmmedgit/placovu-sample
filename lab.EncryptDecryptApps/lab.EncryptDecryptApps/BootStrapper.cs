﻿using lab.EncryptDecryptApps.Helpers;
using lab.EncryptDecryptApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace lab.EncryptDecryptApps
{
    public class BootStrapper
    {
        public static void Run()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Web.config")));
                InitializeAndSeedDb();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Manage(ex, true);
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
    }
}