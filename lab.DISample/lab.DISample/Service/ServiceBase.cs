using lab.DISample.Helpers;
using lab.DISample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace lab.DISample.Service
{
    //public class ServiceBase<T> : IServiceBase<T> where T : class
    //{
    //    #region Private Variable

    //    private readonly IRepositoryBase<T> _iRepositoryBase;
    //    private readonly IUnitOfWork _iUnitOfWork;

    //    #endregion

    //    #region Constructor
    //    public ServiceBase(IRepositoryBase<T> iRepositoryBase, IUnitOfWork iUnitOfWork)
    //    {
    //        this._iRepositoryBase = iRepositoryBase;
    //        this._iUnitOfWork = iUnitOfWork;
    //    }
    //    #endregion

    //    #region Public Virtual Method
    //    public virtual AppMessage Insert(T entity)
    //    {
    //        AppMessage message;
    //        try
    //        {
    //            var affectedRow = 0;
    //            _iRepositoryBase.Insert(entity);
    //            affectedRow = Save();
    //            message = affectedRow > 0
    //                ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
    //                : SetAppMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            return SetAppMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
    //        }
    //        finally
    //        {
    //        }
    //        return message;
    //    }

    //    public virtual AppMessage Update(T entity)
    //    {
    //        AppMessage message;
    //        try
    //        {
    //            var affectedRow = 0;
    //            _iRepositoryBase.Update(entity);
    //            affectedRow = Save();
    //            message = affectedRow > 0
    //               ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.UpdateSuccessMessage)
    //               : SetAppMessage.SetInformationMessage(MessageConstantHelper.UpdateInformationMessage);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            return SetAppMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
    //        }
    //        finally
    //        {
    //        }
    //        return message;
    //    }

    //    public virtual AppMessage Delete(T entity)
    //    {
    //        AppMessage message;
    //        try
    //        {
    //            var affectedRow = 0;
    //            _iRepositoryBase.Delete(entity);
    //            affectedRow = Save();
    //            message = affectedRow > 0
    //                ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.DeleteSuccessMessage)
    //                : SetAppMessage.SetInformationMessage(MessageConstantHelper.DeleteInformationMessage);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            return SetAppMessage.SetErrorMessage(MessageConstantHelper.ErrorCommon);
    //        }
    //        finally
    //        {
    //        }
    //        return message;
    //    }

    //    public virtual T GetById(long id)
    //    {
    //        try
    //        {
    //            return _iRepositoryBase.GetById(id);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            throw exception;
    //        }
    //        finally
    //        {
    //        }
    //    }

    //    public virtual T GetById(string id)
    //    {
    //        try
    //        {
    //            return _iRepositoryBase.GetById(id);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            throw exception;
    //        }
    //        finally
    //        {
    //        }
    //    }

    //    public virtual T Get(Expression<Func<T, bool>> where)
    //    {
    //        try
    //        {
    //            return _iRepositoryBase.Get(where);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            throw exception;
    //        }
    //        finally
    //        {
    //        }
    //    }

    //    public virtual IEnumerable<T> GetAll()
    //    {
    //        try
    //        {
    //            return _iRepositoryBase.GetAll();
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            throw exception;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    //    {
    //        try
    //        {
    //            return _iRepositoryBase.GetMany(where);
    //        }
    //        catch (Exception exception)
    //        {
    //            //Logger code here
    //            ExceptionHelper.ExceptionMessageFormat(exception, true);
    //            //Logger code here
    //            throw exception;
    //        }
    //        finally
    //        {
    //        }
    //    }
    //    public int Save()
    //    {
    //        //return _iRepositoryBase.Save();
    //        return _iUnitOfWork.Commit();
    //    }

    //    #endregion
    //}
    public interface IServiceBase<T> where T : class
    {
        AppMessage Insert(T entity);
        AppMessage Update(T entity);
        AppMessage Delete(T entity);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        int Save();

    }
}