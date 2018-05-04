using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using lab.SecurityApp.Helpers.DataTables;

namespace lab.SecurityApp.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly AppDapperDbContext _dbContext;
        public RoleRepository(AppDapperDbContext dbContext)
           : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<Role> GetAllBySearch(DataTableParamModel param)
        {
            var query = QueryBuilder<Role>.Select();
            return _dbContext.SqlConnection.Query<Role>(query).AsQueryable();
        }
    }


    public interface IRoleRepository : IBaseRepository<Role>
    {
        IQueryable<Role> GetAllBySearch(DataTableParamModel param);
    }
}