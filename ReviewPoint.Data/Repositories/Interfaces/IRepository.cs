using System;
using System.Linq;
using System.Threading.Tasks;
using ReviewPoint.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ReviewPoint.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        ValueTask<T?> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);

    }
}
