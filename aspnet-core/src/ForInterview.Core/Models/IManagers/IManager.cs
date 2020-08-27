using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IManager<T> where T: class, IEntity<int>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindByIdAsync(int id);
    }
}
