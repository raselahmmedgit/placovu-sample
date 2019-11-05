using RnD.Blockchain.Helpers;
using RnD.Blockchain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.Blockchain
{
    public class BootStrapper
    {
        public static void Run()
        {
            try
            {
                InitializeLog4net();

                InitializeAndSeedDb();
            }
            catch (Exception ex)
            {
                ExceptionHelper.Manage(ex, true);
            }

        }

        private static void InitializeLog4net()
        {
            try
            {
                log4net.Config.BasicConfigurator.Configure();
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            }
            catch (Exception)
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
    }
}
