using Abp.Authorization;
using Movie.Authorization.Roles;
using Movie.Authorization.Users;

namespace Movie.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
