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
        /// <summary>
        /// If entity wasn't found, the func returns a default value
        /// </summary>
        /// <param name="id">id of the entity</param>
        Task<T> FindByIdAsync(int id);
    }
}
