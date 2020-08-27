using Abp.Domain.Entities.Auditing;
using ForInterview.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForInterview.Models
{
    public class Evaluation : FullAuditedEntity
    {

        [Required]
        public EvaluationEnum Value { get; set; }

        [Required]
        public int EvaluatorId { get; set; }
        public User Evaluator { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
