using ReviewPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Service.Interfaces
{
    public interface IBaseDataService<TEntity, TViewModel>
         where TEntity : BaseEntity
         where TViewModel : class
    {
        Task Create(TViewModel model);
        Task Delete(Guid id);
        ValueTask<TViewModel> GetByIdAsync(Guid id);
        Task<TEntity> OnBeforeCreate(TViewModel model);
        Task<TEntity> OnBeforeUpdate(TViewModel model);
        Task Update(TViewModel model);
        Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null);
    }
}
