using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace cBaseQms.Core.Repositry.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties

        public cBaseDevEntities DbContext { get; set; }
        private readonly DbSet<T> dbSet;

        //protected IDbFactory DbFactory
        //{
        //    get;
        //    private set;
        //}

        //protected cBaseDevEntities DbContext
        //{
        //    get { return dataContext ?? (dataContext = DbFactory.Init()); }
        //}

        #endregion Properties

        //protected RepositoryBase(IDbFactory dbFactory)
        //{
        //  DbFactory = dbFactory;

        //    dbSet = DbContext.Set<T>();
        //}
        protected RepositoryBase(cBaseDevEntities dataContext)        {
            this.DbContext = dataContext;
            dbSet = dataContext.Set<T>();
        }


        #region Implementation

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(int Id)
        {
            T t = dbSet.Find(Id);
            dbSet.Remove(t);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.AsNoTracking().Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

      
    }

    #endregion Implementation
}