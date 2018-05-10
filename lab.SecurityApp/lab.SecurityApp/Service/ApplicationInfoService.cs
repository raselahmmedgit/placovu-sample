using AutoMapper;
using lab.SecurityApp.Helpers;
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
    public class ApplicationInfoService : ServiceBase<ApplicationInfo>, IApplicationInfoService
    {
        private readonly IApplicationInfoRepository _iApplicationInfoRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public ApplicationInfoService(IRepositoryBase<ApplicationInfo> iRepositoryBase, IApplicationInfoRepository iApplicationInfoRepository, IUnitOfWork iUnitOfWork)
            : base(iRepositoryBase, iUnitOfWork)
        {
            _iApplicationInfoRepository = iApplicationInfoRepository;
        }

        public IQueryable<ApplicationInfoViewModel> GetAllBySearch(DataTableParamModel param)
        {
            var applicationInfoList = _iApplicationInfoRepository.GetAllBySearch(param).ToList();
            var applicationInfoViewModelList = Mapper.Map<List<ApplicationInfo>, List<ApplicationInfoViewModel>>(applicationInfoList);
            return applicationInfoViewModelList.AsQueryable();
        }

        public virtual AppMessage InsertOrUpdate(ApplicationInfoViewModel viewModel)
        {
            AppMessage message;
            try
            {
                var applicationInfo = Mapper.Map<ApplicationInfoViewModel, ApplicationInfo>(viewModel);
                var isExist = _iApplicationInfoRepository.GetById(applicationInfo.ApplicationInfoId);
                if (isExist == null)
                {
                    message = this.Insert(applicationInfo);
                }
                else
                {
                    message = this.Update(applicationInfo);
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
            }
            return message;
        }
    }

    public interface IApplicationInfoService : IServiceBase<ApplicationInfo>
    {
        IQueryable<ApplicationInfoViewModel> GetAllBySearch(DataTableParamModel param);

        AppMessage InsertOrUpdate(ApplicationInfoViewModel viewModel);
    }
}