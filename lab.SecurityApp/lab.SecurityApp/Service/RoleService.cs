using lab.SecurityApp.Helpers;
using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Helpers.DataTables;
using lab.SecurityApp.Models;
using lab.SecurityApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Service
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _iRoleRepository;
        private readonly AppDapperDbContext _dbContext;

        public RoleService(IBaseRepository<Role> iBaseRepository, IRoleRepository iRoleRepository, AppDapperDbContext dbContext)
            : base(iBaseRepository, dbContext)
        {
            _iRoleRepository = iRoleRepository;
            _dbContext = dbContext;
        }

        public IQueryable<Role> GetAllBySearch(DataTableParamModel param)
        {
            return _iRoleRepository.GetAllBySearch(param);
        }
    }

    public interface IRoleService : IBaseService<Role>
    {
        IQueryable<Role> GetAllBySearch(DataTableParamModel param);
    }
}