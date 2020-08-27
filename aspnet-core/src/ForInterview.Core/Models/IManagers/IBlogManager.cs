using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.IManagers
{
    public interface IBlogManager : IDomainService, IManager<Blog>
    {
        IEnumerable<Blog> GetAllBlogs();
        IEnumerable<Blog> GetAllBlogsSortedByPopularity();
    }
}
