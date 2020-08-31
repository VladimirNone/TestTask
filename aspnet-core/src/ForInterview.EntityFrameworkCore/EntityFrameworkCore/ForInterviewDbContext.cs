using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ForInterview.Authorization.Roles;
using ForInterview.Authorization.Users;
using ForInterview.MultiTenancy;
using ForInterview.Models;
using System;

namespace ForInterview.EntityFrameworkCore
{
    public class ForInterviewDbContext : AbpZeroDbContext<Tenant, Role, User, ForInterviewDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public ForInterviewDbContext(DbContextOptions<ForInterviewDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Evaluation>()
                .Property(e => e.Value)
                .HasConversion(
                    v => v.ToString(),
                    v => (EvaluationEnum)Enum.Parse(typeof(EvaluationEnum), v));

            base.OnModelCreating(modelBuilder);
        }
    }
}
