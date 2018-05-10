using MySql.Data.Entity;
using System.Data.Entity;

namespace lab.SecurityApp.MySql.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppDbContext : DbContext
    {

        #region Global Variable Declaration

        #endregion

        #region Constructor
        
        #endregion

        #region Actions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        #endregion

        #region Models
        // Sample Model
        public DbSet<StudentInfo> StudentInfos { get; set; }
        #endregion
    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    //public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {

        }
    }

    #endregion
}
