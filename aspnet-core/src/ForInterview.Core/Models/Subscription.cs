using ForInterview.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ForInterview.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
