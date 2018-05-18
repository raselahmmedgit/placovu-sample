using lab.DISample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace lab.DISample.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Global Variable Declaration
        private AppDbContext _dbContext;

        private readonly IDbSet<T> _iDbSet;

        //protected IDatabaseFactory _iDatabaseFactory
        //{
        //    get;
        //    private set;
        //}

        //protected AppDbContext DataContext
        //{
        //    get { return _dbContext ?? (_dbContext = _iDatabaseFactory.Get()); }
        //}
        #endregion

        #region Constructor
        //protected RepositoryBase(IDatabaseFactory iDatabaseFactory)
        //{
        //    _iDatabaseFactory = iDatabaseFactory;
        //    _iDbSet = DataContext.Set<T>();
        //}

        protected RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _iDbSet = dbContext.Set<T>();
        }
        #endregion

        #region Actions
        public virtual void Insert(T entity)
        {
            _iDbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _iDbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _iDbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _iDbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _iDbSet.Remove(obj);
        }

        public virtual T GetById(long id)
        {
            return _iDbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _iDbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _iDbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _iDbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _iDbSet.Where(where).FirstOrDefault<T>();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        
        #endregion
    }

    public interface IRepositoryBase<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        int Save();
    }
}