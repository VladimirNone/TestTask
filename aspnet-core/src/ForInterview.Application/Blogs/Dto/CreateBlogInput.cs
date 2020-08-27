using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Blogs.Dto
{
    public class CreateBlogInput
    {
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public string Description { get; set; }
    }
}
