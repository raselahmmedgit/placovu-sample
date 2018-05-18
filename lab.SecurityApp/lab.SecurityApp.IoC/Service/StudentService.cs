using lab.SecurityApp.IoC.Models;
using lab.SecurityApp.IoC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.IoC.Service
{
    public class StudentService : ServiceBase<Student>, IStudentService
    {
        private readonly IStudentRepository _iStudentRepository;
        //private readonly IUnitOfWork _iUnitOfWork;

        //public StudentService(IRepositoryBase<Student> iRepositoryBase, IStudentRepository iStudentRepository, IUnitOfWork iUnitOfWork)
        //    : base(iRepositoryBase, iUnitOfWork)
        //{
        //    _iStudentRepository = iStudentRepository;
        //    _iUnitOfWork = iUnitOfWork;
        //}

        public StudentService(IRepositoryBase<Student> iRepositoryBase, AppDbContext dbContext, IStudentRepository iStudentRepository)
            : base(iRepositoryBase, dbContext)
        {
            _iStudentRepository = iStudentRepository;
        }

    }

    public interface IStudentService : IServiceBase<Student>
    {

    }
}