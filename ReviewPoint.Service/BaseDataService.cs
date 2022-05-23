using System;
using ReviewPoint.Data.Repositories;
using ReviewPoint.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using ReviewPoint.Service.Interfaces;
using AutoMapper;

namespace ReviewPoint.Service
{
    public class BaseDataService<TEntity, TViewModel, TRepository> : IBaseDataService<TEntity, TViewModel> where TEntity : BaseEntity where TViewModel : class
        where TRepository : IRepository<TEntity>
    {
        
        protected readonly TRepository repository;
        protected readonly IMapper mapper;

        public BaseDataService(TRepository repository, IMapper mapper)
        {
            repository = repository;
            mapper = mapper;
        }

        public virtual async Task Delete(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public virtual async Task<TEntity> OnBeforeCreate(TViewModel model)
        {
            return mapper.Map<TEntity>(model);
        }

        public virtual async Task Create(TViewModel model)
        {
            var entity = await OnBeforeCreate(model);

            await repository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> OnBeforeUpdate(TViewModel model)
        {
            return mapper.Map<TEntity>(model);
        }

        public async virtual Task Update(TViewModel model)
        {
            var entity = await OnBeforeUpdate(model);

            await repository.UpdateAsync(entity);
        }

        public virtual async ValueTask<TViewModel> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);

            return mapper.Map<TViewModel>(entity);
        }

        public virtual async Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null)
        {
            var expression = mapper.Map<Expression<Func<TEntity, bool>>?>(filter);

            var result = await repository.GetAllAsync(expression);

            return mapper.Map<List<TViewModel>>(result);

        }
    }
}
