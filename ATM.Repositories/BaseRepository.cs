using ATM.Data;
using ATM.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ATM.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity 
    {
        #region Properties

        private readonly ATMDataContext _dbContext;
        private readonly DbSet<T> dbSet;

        #endregion Properties

        protected BaseRepository(ATMDataContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            entity.Created = DateTime.Now;
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        //public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.Where(where).ToList();
        //}

        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await dbSet.Where(where).FirstOrDefaultAsync<T>();
        }

        //public T Get(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.Where(where).FirstOrDefault<T>();
        //}
    }
}