﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using ForInterview.Authorization;
using ForInterview.Authorization.Roles;
using ForInterview.Authorization.Users;
using ForInterview.Models;
using ForInterview.Models.IManagers;
using ForInterview.Roles;
using ForInterview.Roles.Dto;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForInterview.Blogs.Dto
{
    [AbpAuthorize(PermissionNames.Blogs)]
    public class BlogAppService : ApplicationService, IBlogAppService
    {
        private readonly IBlogManager _blogManager;

        public BlogAppService(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        public async Task Create(CreateBlogInput input)
        {
            var blog = ObjectMapper.Map<Blog>(input);
            await _blogManager.CreateAsync(blog);
        }

        public async Task Update(UpdateBlogInput input)
        {
            // Determine user is the author of the blog or not
            (var res, var blog) = await IsOwner(AbpSession.UserId, input.Id);
            if (!res)
                return;

            ObjectMapper.Map(input, blog);
            await _blogManager.UpdateAsync(blog);
        }

        public async Task Delete(DeleteBlogInput input)
        {
            // Determine user is the author of the blog or not
            (var res, var blog) = await IsOwner(AbpSession.UserId, input.Id);
            if (!res)
                return;

            ObjectMapper.Map(input, blog);
            await _blogManager.DeleteAsync(blog);
        }

        [AbpAllowAnonymous]
        public ListResultDto<PopularBlogListOutput> GetBlogsSortedByPopularity()
        {
            // The blogs are sorted by the count of posts. It's temporary solution
            var sortedBlogs = _blogManager.GetAllBlogsSortedByPopularity();
            return new ListResultDto<PopularBlogListOutput>(ObjectMapper.Map<List<PopularBlogListOutput>>(sortedBlogs));
        }

        public async Task<BlogListOutput> GetBlogById(int blogId)
        {
            return ObjectMapper.Map<BlogListOutput>(await _blogManager.FindByIdAsync(blogId));
        }

        protected async Task<(bool, Blog)> IsOwner(long? userId, int blogId)
        {
            var blog = await _blogManager.FindByIdAsync(blogId);
            return (userId == blog.AuthorId, blog);
        }

        public async Task SubcribeUser(int blogId, int userId)
        {
            await _blogManager.Subscribe(userId, blogId);
        }
    }
}
