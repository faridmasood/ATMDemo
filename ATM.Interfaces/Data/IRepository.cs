using ATM.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ATM.Interfaces.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        Task<T> GetByIdAsync(Guid id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        Task<T> GetAsync(Expression<Func<T, bool>> where);
    }
}
