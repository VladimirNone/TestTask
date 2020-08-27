using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ForInterview.Authorization;
using ForInterview.Models;
using ForInterview.Models.IManagers;
using ForInterview.Posts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForInterview.Posts
{
    [AbpAuthorize(PermissionNames.Blogs)]
    public class PostAppService : ApplicationService, IPostAppService
    {
        private readonly IPostManager _postManager;
        private readonly IEvaluationManager _evaluationManager;
        private readonly IBlogManager _blogManager;

        public PostAppService(IPostManager postManager, IEvaluationManager evaluationManager, IBlogManager blogManager)
        {
            _postManager = postManager;
            _evaluationManager = evaluationManager;
            _blogManager = blogManager;
        }

        public async Task Create(CreatePostInput input)
        {
            var blog = await _blogManager.FindByIdAsync(input.BlogId);
            if (blog?.AuthorId != AbpSession.UserId && AbpSession.UserId != input.AuthorId)
                return;

            var post = ObjectMapper.Map<Post>(input);

            await _postManager.CreateAsync(post);

        }

        public async Task Delete(DeletePostInput input)
        {
            (var res, var post) = await IsOwner(AbpSession.UserId, input.Id);
            if (!res)
                return;

            ObjectMapper.Map(input, post);
            await _postManager.DeleteAsync(post);
        }

        [AbpAllowAnonymous]
        public ListResultDto<PostOutput> GetPostsUsingTag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return new ListResultDto<PostOutput>(ObjectMapper.Map<List<PostOutput>>(_postManager.GetAllPosts()));
            return new ListResultDto<PostOutput>(ObjectMapper.Map<List<PostOutput>>(_postManager.GetAllPosts().Where(h => h.Tags.Split().Contains(tag))));
        }

        [AbpAllowAnonymous]
        public async Task<double> GetAverageRatingOfPost(int postId)
        {
            var post = await _postManager.FindByIdAsync(postId);
            return post.Evaluations.Average(x => (int)x.Value);
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<string>> GetTags(int postId)
        {
            var post = await _postManager.FindByIdAsync(postId);
            return new ListResultDto<string>(post.Tags.Split());
        }

        public async Task RatePost(EvaluationDto evaluation)
        { 
            var eval = ObjectMapper.Map<Evaluation>(evaluation);
            eval.EvaluatorId = (int)AbpSession.UserId;

            (var wasFounded, var evalFounded) = await _evaluationManager.TryFindEvaluation(eval);

            if (wasFounded)
            {
                evalFounded.Value = eval.Value;
                await _evaluationManager.UpdateAsync(evalFounded);
            }
            else
                await _evaluationManager.CreateAsync(eval);

        }

        public async Task Update(UpdatePostInput input)
        {
            (var res, var post) = await IsOwner(AbpSession.UserId, input.Id);
            if (!res)
                return;

            ObjectMapper.Map(input, post);
            await _postManager.UpdateAsync(post);
        }

        protected async Task<(bool, Post)> IsOwner(long? userId, int postId)
        {
            var post = await _postManager.FindByIdAsync(postId);
            return (userId == post.AuthorId, post);
        }
    }
}
