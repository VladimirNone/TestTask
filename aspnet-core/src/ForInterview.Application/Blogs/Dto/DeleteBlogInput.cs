using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Blogs.Dto
{
    public class DeleteBlogInput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }
    }
}
