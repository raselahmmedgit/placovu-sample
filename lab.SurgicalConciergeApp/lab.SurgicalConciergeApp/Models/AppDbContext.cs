using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class AppDbContext : DbContext
    {
        #region Baby Boomers

        public DbSet<AspNetUser> AspNetUsers { get; set; }

        public DbSet<SysOrganization> SysOrganizations { get; set; }

        public DbSet<OrganizationType> OrganizationTypes { get; set; }

        public DbSet<BseAddress> BseAddresses { get; set; }

        public DbSet<CompanyProfile> CompanyProfiles { get; set; }

        public DbSet<CompanyProfilePicture> CompanyProfilePictures { get; set; }

        public DbSet<LocationType> LocationTypes { get; set; }

        public DbSet<BseState> BseStates { get; set; }

        public DbSet<BseCountry> BseCountries { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<BseDocument> BseDocuments { get; set; }

        public DbSet<PictureType> PictureTypes { get; set; }

        public DbSet<BsePicture> BsePictures { get; set; }

        public DbSet<TemplateType> TemplateTypes { get; set; }

        public DbSet<BseTemplate> BseTemplates { get; set; }

        public DbSet<SchedulerProfile> SchedulerProfiles { get; set; }

        public DbSet<NurseProfile> NurseProfiles { get; set; }

        public DbSet<ProfessionalProfile> ProfessionalProfiles { get; set; }

        public DbSet<ResidentProfile> ResidentProfiles { get; set; }

        public DbSet<GenderType> GenderTypes { get; set; }

        public DbSet<RelationType> RelationTypes { get; set; }

        public DbSet<ResidentRelativesProfile> ResidentRelativesProfiles { get; set; }

        public DbSet<EmailPriorityType> EmailPriorityTypes { get; set; }

        public DbSet<EmailNotificationType> EmailNotificationTypes { get; set; }

        public DbSet<EmailStatus> EmailStatuses { get; set; }

        public DbSet<ResidentEmailHistory> ResidentEmailHistories { get; set; }

        public DbSet<SmsStatus> SmsStatuses { get; set; }

        public DbSet<ResidentSmsHistory> ResidentSmsHistories { get; set; }

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
    //public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            //// Create default WorkFlowCategory.
            //var workFlowCategories = new List<WorkFlowCategory>
            //                {
            //                    new WorkFlowCategory { WorkFlowCategoryId = 1, Name = "Surgical Concierge"}
            //                };

            //workFlowCategories.ForEach(wfc => context.WorkFlowCategories.Add(wfc));
            //context.SaveChanges();
        }
    }

    #endregion
}