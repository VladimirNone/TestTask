using Abp.Authorization;
using ForInterview.Authorization.Roles;
using ForInterview.Authorization.Users;

namespace ForInterview.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
