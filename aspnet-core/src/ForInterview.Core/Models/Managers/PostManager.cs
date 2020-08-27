using Abp.Domain.Repositories;
using ForInterview.Models.IManagers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Models.Managers
{
    public class PostManager : Manager<Post>, IPostManager
    {
        public PostManager(IRepository<Post> repo) : base(repo)
        {
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return repository.GetAllIncluding(x => x.Evaluations);
        }

        public override async Task<Post> FindByIdAsync(int id)
        {
            return await repository.GetAllIncluding(x => x.Evaluations).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}