using lab.SecurityApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Models
{
    public class AppDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppDbContext() : base("name=AppDbContext")
        {
        }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.ApplicationInfo> ApplicationInfoes { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.DefaultSetting> DefaultSettings { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.DocumentInfoType> DocumentInfoTypes { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.DocumentInfo> DocumentInfoes { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.EmailTemplateCategory> EmailTemplateCategories { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.EmailTemplate> EmailTemplates { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.MenuRolePermission> MenuRolePermissions { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.MenuUserPermission> MenuUserPermissions { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.Right> Rights { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.RightRolePermission> RightRolePermissions { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.RightUserPermission> RightUserPermissions { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.SMSTemplateCategory> SMSTemplateCategories { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.SMSTemplate> SMSTemplates { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.UserActivity> UserActivities { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.UserMetadata> UserMetadatas { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.UserProfile> UserProfiles { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.WidgetCategory> WidgetCategories { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.Widget> Widgets { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.WidgetRolePermission> WidgetRolePermissions { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.WidgetUserPermission> WidgetUserPermissions { get; set; }
    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        //private static void CreateUserWithRole(string username, string password, string email, int roleId, AppDbContext context)
        //{
        //    var user = new User { UserName = username, Password = password, Email = email, IsApproved = true, LastLoginDate = DateTime.UtcNow, LastActivityDate = DateTime.UtcNow, LastPasswordChangeDate = DateTime.UtcNow };
        //    context.Users.Add(user);
        //    context.SaveChanges();

        //    // Add the role.
        //    var existUser = context.Users.Find(user.UserId);
        //    var existRole = context.Roles.Find(roleId);

        //    var userRole = new UserRole { UserId = existUser.UserId, RoleId = existRole.RoleId };
        //    context.UserRoles.Add(userRole);
        //    context.SaveChanges();
        //}

        protected override void Seed(AppDbContext context)
        {
            // Create default roles.
            var roles = new List<Role>
                            {
                                new Role {RoleName = "Admin"},
                                new Role {RoleName = "Employee"},
                                new Role {RoleName = "User"}
                            };

            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            //// Create some users.
            //CreateUserWithRole("Admin", "@123456", "admin@gmail.com", Convert.ToInt32(AppRoles.Admin), context);
            //CreateUserWithRole("Employee", "@123456", "employee@gmail.com", Convert.ToInt32(AppRoles.Employee), context);
            //CreateUserWithRole("User", "@123456", "user@gmail.com", Convert.ToInt32(AppRoles.User), context);
            //CreateUserWithRole("Rasel", "@123456", "raselahmmed@gmail.com", Convert.ToInt32(AppRoles.User), context);

            //// Create Company.
            //List<Company> companyList = new List<Company>
            //                {
            //                    new Company {CompanyId = 1, CompanyName = "RAB", Email = "raselahmmed@gmail.com", Address = "Dhaka", MobileNo = "01911-045573", PhoneNo = "01911-045573"},
            //                };
            //companyList.ForEach(r => context.Companies.Add(r));
            //context.SaveChanges();
            

        }
    }

    #endregion
}
