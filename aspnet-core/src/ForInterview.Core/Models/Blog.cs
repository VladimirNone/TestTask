using Abp.Domain.Entities.Auditing;
using ForInterview.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForInterview.Models
{
    public class Blog : FullAuditedEntity
    {

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public User Author { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
