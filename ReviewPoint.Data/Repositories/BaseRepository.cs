using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewPoint.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ReviewPoint.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ReviewPointDbContext context;

        public BaseRepository(ReviewPointDbContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter);
        }

        public virtual async ValueTask<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {entity.Id}");
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            var set = context.Set<T>().AsQueryable();

            if (filter != null)
            {
                set = set.Where(filter);
            }

            return await set.ToListAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {id}");
            }

            context.Remove(entity);

            await context.SaveChangesAsync();

        }
    }
}
