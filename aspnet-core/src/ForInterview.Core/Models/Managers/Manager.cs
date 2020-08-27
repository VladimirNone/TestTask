using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using ForInterview.Models.IManagers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.Managers
{
    public abstract class Manager<T> : IManager<T> where T : class, IEntity<int>
    {
        protected readonly IRepository<T> repository;

        public Manager(IRepository<T> repo)
        {
            repository = repo;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            return await repository.InsertAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await repository.DeleteAsync(entity);
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await repository.FirstOrDefaultAsync(h => h.Id == id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
