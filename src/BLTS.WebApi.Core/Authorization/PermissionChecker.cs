using Abp.Authorization;
using BLTS.WebApi.Authorization.Roles;
using BLTS.WebApi.Authorization.Users;

namespace BLTS.WebApi.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
