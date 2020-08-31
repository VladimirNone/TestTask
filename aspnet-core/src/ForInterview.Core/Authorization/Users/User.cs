using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using ForInterview.Models;

namespace ForInterview.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public List<Evaluation> Evaluations { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Post> Posts { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
