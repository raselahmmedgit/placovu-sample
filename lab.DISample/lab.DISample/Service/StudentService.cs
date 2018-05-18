using lab.DISample.Helpers;
using lab.DISample.Models;
using lab.DISample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace lab.DISample.Service
{
    #region Wrong Code
    //public class StudentService : ServiceBase<Student>, IStudentService
    //{
    //    private readonly IStudentRepository _iStudentRepository;
    //    private readonly IUnitOfWork _iUnitOfWork;

    //    public StudentService(IRepositoryBase<Student> iRepositoryBase, IStudentRepository iStudentRepository, IUnitOfWork iUnitOfWork)
    //        : base(iRepositoryBase, iUnitOfWork)
    //    {
    //        _iStudentRepository = iStudentRepository;
    //        _iUnitOfWork = iUnitOfWork;
    //    }

    //}

    //public interface IStudentService : IServiceBase<Student>
    //{

    //}
    #endregion

    #region Right Code

    public class StudentService : IStudentService
    {
        #region Global Variable Declaration
        private readonly IStudentRepository _iStudentRepository;
        //private readonly IUnitOfWork _iUnitOfWork;
        #endregion

        #region Constructor
        //public StudentService(IStudentRepository iStudentRepository, IUnitOfWork iUnitOfWork)
        //{
        //    this._iStudentRepository = iStudentRepository;
        //    this._iUnitOfWork = iUnitOfWork;
        //}

        public StudentService(IStudentRepository iStudentRepository)
        {
            this._iStudentRepository = iStudentRepository;
        }

        #endregion

        #region Actions

        public virtual AppMessage Insert(Student entity)
        {
            AppMessage message;
            try
            {
                var affectedRow = 0;
                _iStudentRepository.Insert(entity);
                affectedRow = Save();
                message = affectedRow > 0
                    ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.SaveSuccessMessage)
                    : SetAppMessage.SetInformationMessage(MessageConstantHelper.SaveInformationMessage);
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

        public virtual AppMessage Update(Student entity)
        {
            AppMessage message;
            try
            {
                var affectedRow = 0;
                _iStudentRepository.Update(entity);
                affectedRow = Save();
                message = affectedRow > 0
                   ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.UpdateSuccessMessage)
                   : SetAppMessage.SetInformationMessage(MessageConstantHelper.UpdateInformationMessage);
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

        public virtual AppMessage Delete(Student entity)
        {
            AppMessage message;
            try
            {
                var affectedRow = 0;
                _iStudentRepository.Delete(entity);
                affectedRow = Save();
                message = affectedRow > 0
                    ? SetAppMessage.SetSuccessMessage(MessageConstantHelper.DeleteSuccessMessage)
                    : SetAppMessage.SetInformationMessage(MessageConstantHelper.DeleteInformationMessage);
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

        public virtual Student GetById(long id)
        {
            try
            {
                return _iStudentRepository.GetById(id);
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
            }
        }

        public virtual Student GetById(string id)
        {
            try
            {
                return _iStudentRepository.GetById(id);
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
            }
        }

        public virtual Student Get(Expression<Func<Student, bool>> where)
        {
            try
            {
                return _iStudentRepository.Get(where);
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
            }
        }

        public virtual IEnumerable<Student> GetAll()
        {
            try
            {
                return _iStudentRepository.GetAll();
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
            }
        }

        public virtual IEnumerable<Student> GetMany(Expression<Func<Student, bool>> where)
        {
            try
            {
                return _iStudentRepository.GetMany(where);
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
            }
        }

        public int Save()
        {
            return _iStudentRepository.Save();
        }

        #endregion
    }

    public interface IStudentService : IServiceBase<Student>
    {

    }

    #endregion
}