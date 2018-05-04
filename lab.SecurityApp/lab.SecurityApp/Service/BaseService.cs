using lab.SecurityApp.Helpers;
using lab.SecurityApp.Helpers.Dapper;
using lab.SecurityApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace lab.SecurityApp.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region Private Variable

        private readonly IBaseRepository<T> _iBaseRepository;
        private readonly AppDapperDbContext _dbContext;

        #endregion

        #region Constructor
        public BaseService(IBaseRepository<T> iBaseRepository, AppDapperDbContext dbContext)
        {
            _iBaseRepository = iBaseRepository;
            _dbContext = dbContext;
        }
        #endregion

        #region Public Virtual Method
        public virtual Message InsertOrUpdate(T entity)
        {
            Message message;
            try
            {
                _dbContext.SqlConnection.Open();
                var isExist = _iBaseRepository.Get(entity);
                var affectedRow = 0;
                if (isExist == null)
                {
                    affectedRow = _iBaseRepository.Insert(entity);
                    message = affectedRow > 0
                        ? SetMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                        : SetMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
                }
                else
                {
                    affectedRow = _iBaseRepository.Update(entity);
                    message = affectedRow > 0
                       ? SetMessage.SetSuccessMessage(MessageConstantHelper.UpdateSuccessMessage)
                       : SetMessage.SetInformationMessage(MessageConstantHelper.UpdateInformationMessage);
                }
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                return SetMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
            return message;
        }
        public virtual Message InsertOrUpdateWithoutIdentity(T entity)
        {
            Message message;
            try
            {
                _dbContext.SqlConnection.Open();
                var isExist = _iBaseRepository.Get(entity);
                var affectedRow = 0;
                if (isExist == null)
                {
                    affectedRow = _iBaseRepository.InsertWithoutIdentity(entity);
                    message = affectedRow > 0
                        ? SetMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                        : SetMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
                }
                else
                {
                    affectedRow = _iBaseRepository.Update(entity);
                    message = affectedRow > 0
                       ? SetMessage.SetSuccessMessage(MessageConstantHelper.UpdateSuccessMessage)
                       : SetMessage.SetInformationMessage(MessageConstantHelper.UpdateInformationMessage);
                }

            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                return SetMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
            return message;
        }
        public virtual Message Delete(T entity)
        {
            Message message;
            try
            {
                _dbContext.SqlConnection.Open();
                var affectedRow = 0;
                affectedRow = _iBaseRepository.Delete(entity);
                message = affectedRow > 0
                    ? SetMessage.SetSuccessMessage(MessageConstantHelper.DeleteSuccessMessage)
                    : SetMessage.SetInformationMessage(MessageConstantHelper.DeleteInformationMessage);
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                return SetMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
            return message;
        }
        public virtual T Get(T entity)
        {
            try
            {
                _dbContext.SqlConnection.Open();
                return _iBaseRepository.Get(entity);
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                throw exception;
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
        }

        public T GetWithNavigationProperty(T entity)
        {
            try
            {
                _dbContext.SqlConnection.Open();
                return _iBaseRepository.GetWithNavigationProperty(entity);
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                throw exception;
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                _dbContext.SqlConnection.Open();
                return _iBaseRepository.GetAll();
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                throw exception;
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
        }
        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                _dbContext.SqlConnection.Open();
                return _iBaseRepository.AllIncluding(includeProperties);
            }
            catch (Exception exception)
            {
                //Logger code here
                ExceptionHelper.ExceptionMessageFormat(exception, true);
                //Logger code here
                throw exception;
            }
            finally
            {
                _dbContext.SqlConnection.Close();
            }
        }

        #endregion
    }
    public interface IBaseService<T> where T : class
    {
        Message InsertOrUpdate(T entity);
        Message InsertOrUpdateWithoutIdentity(T entity);
        Message Delete(T entity);
        T Get(T entity);
        T GetWithNavigationProperty(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

    }
}