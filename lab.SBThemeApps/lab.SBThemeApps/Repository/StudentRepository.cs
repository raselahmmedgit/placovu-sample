using lab.SBThemeApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SBThemeApps.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

    public interface IStudentRepository : IRepositoryBase<Student>
    {
    }
}