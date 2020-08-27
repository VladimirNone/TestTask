using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Posts.Dto
{
    public class UpdatePostInput
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public int AuthorId { get; set; }

        public string Tags { get; set; }
    }
}
