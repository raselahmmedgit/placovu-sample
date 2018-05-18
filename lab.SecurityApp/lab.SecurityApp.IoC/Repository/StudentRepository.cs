using lab.SecurityApp.IoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.IoC.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        //public StudentRepository(IDatabaseFactory iDatabaseFactory)
        //    : base(iDatabaseFactory)
        //{
        //}

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