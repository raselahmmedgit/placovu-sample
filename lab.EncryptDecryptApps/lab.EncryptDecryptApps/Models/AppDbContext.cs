using lab.EncryptDecryptApps.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace lab.EncryptDecryptApps.Models
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //    : base("name=AppDbContext")
        //{
        //}

        //public AppDbContext()
        //    : base(SiteConfigurationReader.ConnectionString)
        //{
        //}

        public AppDbContext()
            : base(ConnectionStringHelper.ConnectionString)
        {
        }

        public DbSet<Student> Students { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ContactJobTiteRatingStaffingRate>()
            //        .Map(e => e.ToTable("ContactJobTiteRatingStaffingRate"));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            // Create default roles.
            List<Student> students = new List<Student>
                            {
                                new Student {Id=1, Name = "Rasel", EmailAddress = "rasel@mail.com", Mobile = "01911-555555"},
                                new Student {Id=2, Name = "Sohel", EmailAddress = "sohel@mail.com", Mobile = "01911-666666"},
                                new Student {Id=3, Name = "Safin", EmailAddress = "safin@mail.com", Mobile = "01911-777777"},
                                new Student {Id=4, Name = "Mim", EmailAddress = "mim@mail.com", Mobile = "01911-888888"},
                                new Student {Id=5, Name = "Bappi", EmailAddress = "bappi@mail.com", Mobile = "01911-999999"}
                            };

            students.ForEach(r => context.Students.Add(r));
            context.SaveChanges();
        }
    }

    #endregion
}