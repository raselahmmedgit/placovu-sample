using AutoMapper;
using lab.SecurityApp.Helpers;
using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Helpers.DataTables;
using lab.SecurityApp.Models;
using lab.SecurityApp.Repository;
using lab.SecurityApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.Service
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _iRoleRepository;

        public RoleService(IBaseRepository<Role> iBaseRepository, AppDapperDbContext dbContext, IRoleRepository iRoleRepository)
            : base(iBaseRepository, dbContext)
        {
            _iRoleRepository = iRoleRepository;
        }

        public IQueryable<RoleViewModel> GetAllBySearch(DataTableParamModel param)
        {
            var roleList = _iRoleRepository.GetAllBySearch(param).ToList();
            var roleViewModelList = Mapper.Map<List<Role>, List<RoleViewModel>>(roleList);
            return roleViewModelList.AsQueryable();
        }

        public virtual AppMessage InsertOrUpdate(RoleViewModel viewModel)
        {
            AppMessage message;
            try
            {
                var role = Mapper.Map<RoleViewModel, Role>(viewModel);
                message = this.InsertOrUpdate(role);
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                return SetAppMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
            }
            
            return message;
        }
    }

    public interface IRoleService : IBaseService<Role>
    {
        IQueryable<RoleViewModel> GetAllBySearch(DataTableParamModel param);

        AppMessage InsertOrUpdate(RoleViewModel viewModel);
    }
}