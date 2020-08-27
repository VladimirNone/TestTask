using ForInterview.Posts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Blogs.Dto
{
    public class BlogListOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public string Description { get; set; }

        public List<PostOutput> Posts { get; set; }
    }
}
