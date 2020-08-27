using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ForInterview.Models;
using ForInterview.Posts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Posts
{
    public interface IPostAppService : IApplicationService
    {
        Task Create(CreatePostInput input);
        Task Update(UpdatePostInput input);
        Task Delete(DeletePostInput input);
        Task RatePost(EvaluationDto evaluation);
        Task<double> GetAverageRatingOfPost(int postId);
        Task<ListResultDto<string>> GetTags(int postId);
        ListResultDto<PostOutput> GetPostsUsingTag(string tag);
    }
}
