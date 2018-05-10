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
        private readonly AppDapperDbContext _dbContext;

        public RoleService(IBaseRepository<Role> iBaseRepository, IRoleRepository iRoleRepository, AppDapperDbContext dbContext)
            : base(iBaseRepository, dbContext)
        {
            _iRoleRepository = iRoleRepository;
            _dbContext = dbContext;
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
                _dbContext.SqlConnection.Open();
                var isExist = _iRoleRepository.Get(role);
                var affectedRow = 0;
                if (isExist == null)
                {
                    affectedRow = _iRoleRepository.Insert(role);
                    message = affectedRow > 0
                        ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                        : SetAppMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
                }
                else
                {
                    affectedRow = _iRoleRepository.Update(role);
                    message = affectedRow > 0
                       ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.UpdateSuccessMessage)
                       : SetAppMessage.SetInformationMessage(MessageConstantHelper.UpdateInformationMessage);
                }
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                return SetAppMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
            }
            finally
            {
                _dbContext.SqlConnection.Close();
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