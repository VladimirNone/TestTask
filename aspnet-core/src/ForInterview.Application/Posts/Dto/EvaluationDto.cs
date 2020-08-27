using ForInterview.Authorization.Users;
using ForInterview.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForInterview.Posts.Dto
{
    public class EvaluationDto
    {
        public EvaluationEnum Value { get; set; }

        public int EvaluatorId { get; set; }

        public int PostId { get; set; }
    }
}
