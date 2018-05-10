using lab.SecurityApp.Models;
using System;

namespace lab.SecurityApp.Repository
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