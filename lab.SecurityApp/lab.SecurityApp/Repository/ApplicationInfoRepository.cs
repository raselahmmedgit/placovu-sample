using lab.SecurityApp.Helpers.DataTables;
using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Repository
{
    public class ApplicationInfoRepository : RepositoryBase<ApplicationInfo>, IApplicationInfoRepository
    {
        public ApplicationInfoRepository(IDatabaseFactory iDatabaseFactory)
            : base(iDatabaseFactory)
        {
        }

        public virtual IQueryable<ApplicationInfo> GetAllBySearch(DataTableParamModel param)
        {
            return this.GetAll().AsQueryable();
        }
    }

    public interface IApplicationInfoRepository : IRepositoryBase<ApplicationInfo>
    {
        IQueryable<ApplicationInfo> GetAllBySearch(DataTableParamModel param);
    }
}