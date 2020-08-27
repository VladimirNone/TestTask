using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ForInterview.Models.IManagers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.Managers
{
    class BlogManager : Manager<Blog>, IBlogManager
    {
        public BlogManager(IRepository<Blog> repository)
            : base(repository)
        {
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return repository.GetAll();
        }

        public IEnumerable<Blog> GetAllBlogsSortedByPopularity()
        {
            return repository.GetAll().OrderBy(x => x.Posts.Count);
        }

        public override async Task<Blog> FindByIdAsync(int id)
        {
            return await repository.GetAllIncluding(x => x.Posts).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
