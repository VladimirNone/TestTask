using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ForInterview.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Blogs.Dto
{
    public interface IBlogAppService : IApplicationService
    {
        Task Create(CreateBlogInput input);
        Task Update(UpdateBlogInput input);
        Task Delete(DeleteBlogInput input);
        Task SubcribeUser(int blogId, int userId);
        Task<BlogListOutput> GetBlogById(int blogId);
        ListResultDto<PopularBlogListOutput> GetBlogsSortedByPopularity();
    }
}
