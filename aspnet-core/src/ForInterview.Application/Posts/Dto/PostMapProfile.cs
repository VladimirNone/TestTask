using AutoMapper;
using ForInterview.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Posts.Dto
{
    public class PostMapProfile:Profile
    {
        public PostMapProfile()
        {
            CreateMap<CreatePostInput, Post>();
            CreateMap<DeletePostInput, Post>();
            CreateMap<UpdatePostInput, Post>();
                //.ForMember(x=>x.Id, opt => opt.Ignore());
            CreateMap<EvaluationDto, Evaluation>();
            CreateMap<Evaluation, EvaluationDto>();
            CreateMap<Post, PostOutput>()
                .ForMember(x=>x.Evaluations, opt=>opt.MapFrom(x=>x.Evaluations));
        }
    }
}
