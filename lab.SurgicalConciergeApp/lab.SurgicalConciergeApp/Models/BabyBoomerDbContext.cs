using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class BabyBoomerDbContext : DbContext
    {

        #region Baby Boomers

        public DbSet<BabyBoomerProfile> BabyBoomerProfiles { get; set; }
        public DbSet<BabyBoomerAttendeeProfileType> BabyBoomerAttendeeProfileTypes { get; set; }
        public DbSet<BabyBoomerAttendeeProfile> BabyBoomerAttendeeProfiles { get; set; }
        public DbSet<BabyBoomerActivityType> BabyBoomerActivityTypes { get; set; }
        public DbSet<BabyBoomerActivity> BabyBoomerActivities { get; set; }
        public DbSet<BabyBoomerActivityDetail> BabyBoomerActivityDetails { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class BabyBoomerDbInitializer : DropCreateDatabaseAlways<BabyBoomerDbContext>
    //public class BabyBoomerDbInitializer : CreateDatabaseIfNotExists<BabyBoomerDbContext>
    public class BabyBoomerDbInitializer : DropCreateDatabaseIfModelChanges<BabyBoomerDbContext>
    {
        protected override void Seed(BabyBoomerDbContext context)
        {
            // Create default WorkFlowCategory.
            var babyBoomerActivityTypes = new List<BabyBoomerActivityType>
                            {
                                new BabyBoomerActivityType { ActivityTypeId = new Guid(), Name = "A"}
                            };

            babyBoomerActivityTypes.ForEach(wfc => context.BabyBoomerActivityTypes.Add(wfc));
            context.SaveChanges();

        }
    }

    #endregion
}