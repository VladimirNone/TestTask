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
            return repository.GetAllIncluding(x => x.Subscriptions).OrderByDescending(x => x.Subscriptions.Count);
        }

        public override async Task<Blog> FindByIdAsync(int id)
        {
            return await repository.GetAllIncluding(x => x.Posts).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Subscribe(int userId, int blogId)
        {
            var blog = await repository.GetAllIncluding(x => x.Subscriptions).SingleOrDefaultAsync(x => x.Id == blogId);

            if(!blog.Subscriptions.Any(h=>h.UserId == userId && h.BlogId == blogId))
                blog.Subscriptions.Add(new Subscription() { BlogId = blogId, UserId = userId });
        }
    }
}