using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.Blockchain.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<BabyBoomerProfile> BabyBoomerProfiles { get; set; }
        public DbSet<BabyBoomerAttendeeProfileType> BabyBoomerAttendeeProfileTypes { get; set; }
        public DbSet<BabyBoomerAttendeeProfile> BabyBoomerAttendeeProfiles { get; set; }
        public DbSet<BabyBoomerActivityType> BabyBoomerActivityTypes { get; set; }
        public DbSet<BabyBoomerActivity> BabyBoomerActivities { get; set; }
        public DbSet<BabyBoomerActivityDetail> BabyBoomerActivityDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
            // Create default BabyBoomerAttendeeProfileType.
            var babyBoomerAttendeeProfileTypes = new List<BabyBoomerAttendeeProfileType>
                            {
                                new BabyBoomerAttendeeProfileType { AttendeeProfileTypeId = 1, Name = "Dad"}
                            };

            babyBoomerAttendeeProfileTypes.ForEach(apt => context.BabyBoomerAttendeeProfileTypes.Add(apt));
            context.SaveChanges();

        }
    }

    #endregion
}
