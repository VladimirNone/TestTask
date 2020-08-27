using ForInterview.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Posts.Dto
{
    public class PostOutput
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public int AuthorId { get; set; }

        public string Tags { get; set; }

        public List<EvaluationDto> Evaluations { get; set; }
    }
}
