using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Posts.Dto
{
    public class DeletePostInput
    {
        public int Id { get; set; }

        public int BlogId { get; set; }

        public int AuthorId { get; set; }
    }
}
