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

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.ApplicationInfo> ApplicationInfos { get; set; }

        public System.Data.Entity.DbSet<lab.SecurityApp.Models.ApplicationSetting> ApplicationSettings { get; set; }

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

        protected override void Seed(AppDbContext context)
        {
            #region Application

            // Create Default User.
            var userList = new List<User>
                {
                    new User {UserId = Convert.ToInt32(UserEnum.SuperAdmin), UserName = UserEnum.SuperAdmin.ToString(), Password = Password.GetBytes("admin123456"),  Email = "schemaplug@gmail.com", LastPasswordChangeDate = DateTime.Now, CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                    new User {UserId = Convert.ToInt32(UserEnum.Admin), UserName = UserEnum.Admin.ToString(), Password = Password.GetBytes("admin123456"),  Email = "schemaplug@gmail.com", LastPasswordChangeDate = DateTime.Now, CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                    new User {UserId = Convert.ToInt32(UserEnum.Employee), UserName = UserEnum.Employee.ToString(), Password = Password.GetBytes("admin123456"),  Email = "schemaplug@gmail.com", LastPasswordChangeDate = DateTime.Now, CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                    new User {UserId = Convert.ToInt32(UserEnum.User), UserName = UserEnum.Employee.ToString(), Password = Password.GetBytes("admin123456"),  Email = "schemaplug@gmail.com", LastPasswordChangeDate = DateTime.Now, CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now}

                };
            userList.ForEach(item => context.Users.Add(item));
            context.SaveChanges();

            // Create Default Role.
            var roleList = new List<Role>
                    {
                        new Role {RoleId = Convert.ToInt32(RoleEnum.SuperAdmin), RoleName = RoleEnum.SuperAdmin.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Role {RoleId = Convert.ToInt32(RoleEnum.Admin), RoleName = RoleEnum.Admin.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Role {RoleId = Convert.ToInt32(RoleEnum.Employee), RoleName = RoleEnum.Employee.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Role {RoleId = Convert.ToInt32(RoleEnum.User), RoleName = RoleEnum.Employee.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now}


                    };
            roleList.ForEach(item => context.Roles.Add(item));
            context.SaveChanges();



            // Create Default UserRole.
            var userRoleList = new List<UserRole>
                    {
                        new UserRole {RoleId = Convert.ToInt32(RoleEnum.SuperAdmin), UserId = Convert.ToInt32(UserEnum.SuperAdmin)},
                        new UserRole {RoleId = Convert.ToInt32(RoleEnum.Admin), UserId = Convert.ToInt32(UserEnum.SuperAdmin)},
                        new UserRole {RoleId = Convert.ToInt32(RoleEnum.Employee), UserId = Convert.ToInt32(UserEnum.SuperAdmin)},
                        new UserRole {RoleId = Convert.ToInt32(RoleEnum.User), UserId = Convert.ToInt32(UserEnum.SuperAdmin)}
                    };
            userRoleList.ForEach(item => context.UserRoles.Add(item));
            context.SaveChanges();

            // Create Default Right.
            var appRightList = new List<Right>
                    {
                        new Right {RightId = Convert.ToInt32(RightEnum.Add), Name = RightEnum.Add.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Edit), Name = RightEnum.Edit.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Details), Name = RightEnum.Details.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Delete), Name = RightEnum.Delete.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.DeleteBulk), Name = RightEnum.DeleteBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Archive), Name = RightEnum.Archive.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ArchiveBulk), Name = RightEnum.ArchiveBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Remove), Name = RightEnum.Remove.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.RemoveBulk), Name = RightEnum.RemoveBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Assign), Name = RightEnum.Assign.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Approve), Name = RightEnum.Approve.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.SendEmail), Name = RightEnum.SendEmail.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.SendEmailBulk), Name = RightEnum.SendEmailBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.SendSMS), Name = RightEnum.SendSMS.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.SendSMSBulk), Name = RightEnum.SendSMSBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ImportExcel), Name = RightEnum.ImportExcel.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ImportCsv), Name = RightEnum.ImportCsv.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ExportExcel), Name = RightEnum.ExportExcel.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ExportCsv), Name = RightEnum.ExportCsv.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ImportVCard), Name = RightEnum.ImportVCard.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ExportVCard), Name = RightEnum.ExportVCard.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.ExportVCardBulk), Name = RightEnum.ExportVCardBulk.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Call), Name = RightEnum.Call.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Print), Name = RightEnum.Print.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Download), Name = RightEnum.Download.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new Right {RightId = Convert.ToInt32(RightEnum.Upload), Name = RightEnum.Upload.ToString(), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now}

                    };
            appRightList.ForEach(item => context.Rights.Add(item));
            context.SaveChanges();

            // Create Default RightRolePermission.
            var appRightPermissionList = new List<RightRolePermission>
                    {
                        #region SuperAdmin
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Add), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Edit), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Details), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Delete), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.DeleteBulk), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Archive), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ArchiveBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Remove), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.RemoveBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Assign), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Approve), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendEmail), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendEmailBulk), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendSMS), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendSMSBulk), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportExcel), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportCsv), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportExcel), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportCsv), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportVCard), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportVCard), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportVCardBulk), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Call), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Print), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Download), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Upload), RoleId = Convert.ToInt32(RoleEnum.SuperAdmin)},
	                    #endregion
                        
                        #region Admin
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Add), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Edit), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Details), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Archive), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ArchiveBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Remove), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.RemoveBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Assign), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Approve), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendEmail), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendEmailBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendSMS), RoleId = Convert.ToInt32(RoleEnum.Admin), CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.SendSMSBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportExcel), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportCsv), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportExcel), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportCsv), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ImportVCard), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportVCard), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.ExportVCardBulk), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Call), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Print), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Download), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        new RightRolePermission {RightId = Convert.ToInt32(RightEnum.Upload), RoleId = Convert.ToInt32(RoleEnum.Admin)},
                        #endregion

                    };
            appRightPermissionList.ForEach(item => context.RightRolePermissions.Add(item));
            context.SaveChanges();

            // Create Default ApplicationSetting.
            var applicationSettingList = new List<ApplicationSetting>
                    {
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.PageSize), Name = "Page Size", Key = ApplicationSettingEnum.PageSize.ToString(), Value = "20", Description = "Grid, List View Default Page Size", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.Version), Name = "Application Version", Key = ApplicationSettingEnum.Version.ToString(), Value = "1.0", Description = "Application Version", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.CacheTimeout), Name = "Cache Timeout", Key = ApplicationSettingEnum.CacheTimeout.ToString(), Value = "5", Description = "Cache Timeout", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.SessionTimeout), Name = "Session Timeout", Key = ApplicationSettingEnum.SessionTimeout.ToString(), Value = "5", Description = "Session Timeout", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.SendEmailPerMinute), Name = "Send Email Per Minute", Key = ApplicationSettingEnum.SendEmailPerMinute.ToString(), Value = "30", Description = "Send Email Per Minute", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationSetting {ApplicationSettingId = Convert.ToInt32(ApplicationSettingEnum.SendSMSPerMinute), Name = "Send SMS Per Minute", Key = ApplicationSettingEnum.SendSMSPerMinute.ToString(), Value = "30", Description = "Send SMS Per Minute", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now}
                    };
            applicationSettingList.ForEach(item => context.ApplicationSettings.Add(item));
            context.SaveChanges();

            // Create Default ApplicationInfo.
            var applicationInfoList = new List<ApplicationInfo>
                    {
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.HeaderTitle), Name = "Application Title", Key = ApplicationInformationEnum.HeaderTitle.ToString(), Value = "title", Description = "Application Title", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.HeaderText), Name = "Application Header Text", Key = ApplicationInformationEnum.HeaderText.ToString(), Value = "header", Description = "Application Header Text", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.HeaderUrl), Name = "Application Header Url", Key = ApplicationInformationEnum.HeaderUrl.ToString(), Value = "#", Description = "Application Header Url", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.MetaAuthor), Name = "Head Meta Author", Key = ApplicationInformationEnum.MetaAuthor.ToString(), Value = "meta author", Description = "Head Meta Author", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.MetaKeywords), Name = "Head Meta Keywords", Key = ApplicationInformationEnum.MetaKeywords.ToString(), Value = "meta keywords", Description = "Head Meta Keywords", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.MetaDescription), Name = "Head Meta Description", Key = ApplicationInformationEnum.MetaDescription.ToString(), Value = "meta description", Description = "Head Meta Description", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.FooterText), Name = "Application Footer Text", Key = ApplicationInformationEnum.FooterText.ToString(), Value = "footer", Description = "Application Footer Text", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now},
                        new ApplicationInfo {ApplicationInfoId = Convert.ToInt32(ApplicationInformationEnum.FooterUrl), Name = "Application Footer Url", Key = ApplicationInformationEnum.FooterUrl.ToString(), Value = "#", Description = "Application Footer Url", CreatedBy = Convert.ToInt32(UserEnum.SuperAdmin), CreatedDate = DateTime.Now, UpdatedBy = Convert.ToInt32(UserEnum.SuperAdmin), UpdatedDate = DateTime.Now, IsDelete = false, DeletedBy = Convert.ToInt32(UserEnum.SuperAdmin), DeletedDate = DateTime.Now}
                    };
            applicationInfoList.ForEach(item => context.ApplicationInfos.Add(item));
            context.SaveChanges();

            // Create Default EmailTemplateCategory.
            var emailTemplateCategoryList = new List<EmailTemplateCategory>
                    {
                        new EmailTemplateCategory { EmailTemplateCategoryId = Convert.ToInt32(EmailTemplateCategoryEnum.SuperAdminTemplate), Name = EmailTemplateCategoryEnum.SuperAdminTemplate.ToDescriptionAttr()},
                        new EmailTemplateCategory { EmailTemplateCategoryId = Convert.ToInt32(EmailTemplateCategoryEnum.AdminTemplate), Name = EmailTemplateCategoryEnum.AdminTemplate.ToDescriptionAttr()}
                    };
            emailTemplateCategoryList.ForEach(item => context.EmailTemplateCategories.Add(item));
            context.SaveChanges();

            // Create Default SMSTemplateCategory.
            var sMSTemplateCategoryList = new List<SMSTemplateCategory>
                    {
                        new SMSTemplateCategory { SMSTemplateCategoryId = Convert.ToInt32(SMSTemplateCategoryEnum.SuperAdminTemplate), Name = SMSTemplateCategoryEnum.SuperAdminTemplate.ToDescriptionAttr()},
                        new SMSTemplateCategory { SMSTemplateCategoryId = Convert.ToInt32(SMSTemplateCategoryEnum.AdminTemplate), Name = SMSTemplateCategoryEnum.AdminTemplate.ToDescriptionAttr()}
                    };
            sMSTemplateCategoryList.ForEach(item => context.SMSTemplateCategories.Add(item));
            context.SaveChanges();

            // Create Default WidgetCategory.
            var widgetCategoryList = new List<WidgetCategory>
                    {
                        new WidgetCategory { WidgetCategoryId = Convert.ToInt32(WidgetCategoryEnum.SuperAdminWidget), Name = WidgetCategoryEnum.SuperAdminWidget.ToDescriptionAttr()},
                        new WidgetCategory { WidgetCategoryId = Convert.ToInt32(WidgetCategoryEnum.AdminWidget), Name = WidgetCategoryEnum.AdminWidget.ToDescriptionAttr()},
                        new WidgetCategory { WidgetCategoryId = Convert.ToInt32(WidgetCategoryEnum.UserWidget), Name = WidgetCategoryEnum.UserWidget.ToDescriptionAttr()}
                    };
            widgetCategoryList.ForEach(item => context.WidgetCategories.Add(item));
            context.SaveChanges();

            // Create Default DocumentInfoType.
            var documentInfoTypeList = new List<DocumentInfoType>
                    {
                        new DocumentInfoType { DocumentInfoTypeId = Convert.ToInt32(DocumentInfoTypeEnum.SuperAdminType), Name = DocumentInfoTypeEnum.SuperAdminType.ToDescriptionAttr()},
                        new DocumentInfoType { DocumentInfoTypeId = Convert.ToInt32(DocumentInfoTypeEnum.AdminType), Name = DocumentInfoTypeEnum.AdminType.ToDescriptionAttr()},
                        new DocumentInfoType { DocumentInfoTypeId = Convert.ToInt32(DocumentInfoTypeEnum.UserType), Name = DocumentInfoTypeEnum.UserType.ToDescriptionAttr()}
                    };
            documentInfoTypeList.ForEach(item => context.DocumentInfoTypes.Add(item));
            context.SaveChanges();

            #endregion
        }
    }

    #endregion
}
