using RnD.AzureLoadBalancer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace lRnD.AzureLoadBalancer.Models
{
    public class OntrackHealthEntities : DbContext
    {
        #region Baby Boomers

        public virtual DbSet<ApplicationSetting> ApplicationSettings { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
    
}