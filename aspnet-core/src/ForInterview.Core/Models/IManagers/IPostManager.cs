using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IPostManager : IDomainService, IManager<Post>
    {
        /// <summary>
        /// Get all blogs with loaded evaluations 
        /// </summary>
        IEnumerable<Post> GetAllPosts();
    }
}
