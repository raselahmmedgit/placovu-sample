using lab.SecurityApp.IoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.SecurityApp.IoC.Repository
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AppDbContext _dataContext;

        public AppDbContext Get()
        {
            return _dataContext ?? (_dataContext = new AppDbContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }

    public interface IDatabaseFactory : IDisposable
    {
        AppDbContext Get();
    }
}