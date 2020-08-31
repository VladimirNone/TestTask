using ForInterview.Authorization.Users;
using ForInterview.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Blogs.Dto
{
    public class PopularBlogListOutput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }

        public int CountOfSubscriptions { get; set; }

        public string Description { get; set; }
    }
}
