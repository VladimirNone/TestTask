using Abp.Domain.Entities.Auditing;
using ForInterview.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForInterview.Models
{
    public class Post : FullAuditedEntity
    { 

        [Required]
        public string Content { get; set; }

        [Required]
        public int BlogId { get; set; } 
        public Blog Blog { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public string Tags { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
