using AutoMapper;
using ForInterview.Authorization.Users;
using ForInterview.Models;
using ForInterview.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Blogs.Dto
{
    public class BlogMapProfile:Profile
    {
        public BlogMapProfile()
        {

            CreateMap<CreateBlogInput, Blog>();
            CreateMap<DeleteBlogInput, Blog>();
            CreateMap<UpdateBlogInput, Blog>();

            CreateMap<Blog, PopularBlogListOutput>()
                .ForMember(x => x.CountOfSubscriptions, opt => opt.MapFrom(h => h.Subscriptions.Count));

            CreateMap<Blog, BlogListOutput>()
                .ForMember(x => x.Posts, opt => opt.MapFrom(h => h.Posts));

        }
    }
}
