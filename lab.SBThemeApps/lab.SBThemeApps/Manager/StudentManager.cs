using lab.SBThemeApps.Models;
using lab.SBThemeApps.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SBThemeApps.Manager
{
    public class StudentManager : ManagerBase<Student>, IStudentManager
    {
        private readonly IStudentRepository _iStudentRepository;

        public StudentManager(IRepositoryBase<Student> iRepositoryBase, AppDbContext dbContext, IStudentRepository iStudentRepository)
            : base(iRepositoryBase, dbContext)
        {
            _iStudentRepository = iStudentRepository;
        }

    }

    public interface IStudentManager : IManagerBase<Student>
    {

    }
}