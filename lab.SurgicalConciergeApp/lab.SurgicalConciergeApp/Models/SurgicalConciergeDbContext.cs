using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace lab.SurgicalConciergeApp.Models
{
    public class SurgicalConciergeDbContext : DbContext
    {
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<WorkFlowCategory> WorkFlowCategories { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkFlowProcedure> WorkFlowProcedures { get; set; }
        public DbSet<WorkFlowPatientProfile> WorkFlowPatientProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class SurgicalConciergeDbInitializer : DropCreateDatabaseAlways<SurgicalConciergeDbContext>
    //public class SurgicalConciergeDbInitializer : CreateDatabaseIfNotExists<SurgicalConciergeDbContext>
    public class SurgicalConciergeDbInitializer : DropCreateDatabaseIfModelChanges<SurgicalConciergeDbContext>
    {
        protected override void Seed(SurgicalConciergeDbContext context)
        {
            // Create default WorkFlowCategory.
            var workFlowCategories = new List<WorkFlowCategory>
                            {
                                new WorkFlowCategory { WorkFlowCategoryId = 1, Name = "Surgical Concierge"}
                            };

            workFlowCategories.ForEach(wfc => context.WorkFlowCategories.Add(wfc));
            context.SaveChanges();

            // Create default WorkFlow.
            var workFlows = new List<WorkFlow>
                            {
                                new WorkFlow { WorkFlowId = 1, WorkFlowCategoryId = 1, Name = "In Room / Anesthesia Induction"},
                                new WorkFlow { WorkFlowId = 2, WorkFlowCategoryId = 1, Name = "Surgery Start "},
                                new WorkFlow { WorkFlowId = 3, WorkFlowCategoryId = 1, Name = "Robot Docked"},
                                new WorkFlow { WorkFlowId = 4, WorkFlowCategoryId = 1, Name = "Posterior Dissection"},
                                new WorkFlow { WorkFlowId = 5, WorkFlowCategoryId = 1, Name = "Lymph Node Dissection"},
                                new WorkFlow { WorkFlowId = 6, WorkFlowCategoryId = 1, Name = "Prostate removal"},
                                new WorkFlow { WorkFlowId = 7, WorkFlowCategoryId = 1, Name = "Anastomosis"},
                                new WorkFlow { WorkFlowId = 8, WorkFlowCategoryId = 1, Name = "Foley Catheter"},
                                new WorkFlow { WorkFlowId = 9, WorkFlowCategoryId = 1, Name = "Undocking"},
                                new WorkFlow { WorkFlowId = 10, WorkFlowCategoryId = 1, Name = "Closed"},
                                new WorkFlow { WorkFlowId = 11, WorkFlowCategoryId = 1, Name = "Out of Room"}
                            };

            workFlows.ForEach(wf => context.WorkFlows.Add(wf));
            context.SaveChanges();

            // Create default Procedure.
            var procedures = new List<Procedure>
                            {
                                new Procedure { ProcedureId = 1, Name = "Robotic Module"}
                            };

            procedures.ForEach(p => context.Procedures.Add(p));
            context.SaveChanges();

            // Create default PatientProfile.
            var patientProfiles = new List<PatientProfile>
                            {
                                new PatientProfile { PatientProfileId = 1, Name = "Mr. Will Paul"}
                            };

            patientProfiles.ForEach(p => context.PatientProfiles.Add(p));
            context.SaveChanges();

            // Create default WorkFlowProcedure.
            var workFlowProcedures = new List<WorkFlowProcedure>
                            {
                                new WorkFlowProcedure { WorkFlowProcedureId = 1, WorkFlowId = 1, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 2, WorkFlowId = 2, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 3, WorkFlowId = 3, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 4, WorkFlowId = 4, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 5, WorkFlowId = 5, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 6, WorkFlowId = 6, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 7, WorkFlowId = 7, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 8, WorkFlowId = 8, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 9, WorkFlowId = 9, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 10, WorkFlowId = 10, ProcedureId = 1},
                                new WorkFlowProcedure { WorkFlowProcedureId = 11, WorkFlowId = 11, ProcedureId = 1}
                            };

            workFlowProcedures.ForEach(wfp => context.WorkFlowProcedures.Add(wfp));
            context.SaveChanges();
        }
    }

    #endregion
}