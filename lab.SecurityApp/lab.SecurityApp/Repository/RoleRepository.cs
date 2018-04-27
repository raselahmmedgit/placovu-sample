using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


    }


    public interface IRoleRepository : IBaseRepository<Role>
    {
    }
}