using lab.DISample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.DISample.Repository
{
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly IDatabaseFactory _iDatabaseFactory;
    //    private AppDbContext _dataContext;

    //    public UnitOfWork(IDatabaseFactory iDatabaseFactory)
    //    {
    //        this._iDatabaseFactory = iDatabaseFactory;
    //    }

    //    protected AppDbContext DataContext
    //    {
    //        get { return _dataContext ?? (_dataContext = _iDatabaseFactory.Get()); }
    //    }

    //    //public void Commit()
    //    //{
    //    //    DataContext.SaveChanges();
    //    //}

    //    public int Commit()
    //    {
    //        return DataContext.SaveChanges();
    //    }
    //}

    //public interface IUnitOfWork
    //{
    //    //void Commit();
    //    int Commit();
    //}
}