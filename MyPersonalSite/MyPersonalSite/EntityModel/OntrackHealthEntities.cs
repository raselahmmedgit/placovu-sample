namespace MyPersonalSite.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OntrackHealthEntities : DbContext
    {
        public OntrackHealthEntities()
            : base("name=OntrackHealthEntities")
        {
        }
        public virtual DbSet<PatientSurveyActivityView> PatientSurveyActivityViews { get; set; }
        public virtual DbSet<PatientSurveyActivityDetailView> PatientSurveyActivityDetailViews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<StudentInfo>()
                .Property(e => e.RowVersion)
                .IsConcurrencyToken();
        }
    }
}
