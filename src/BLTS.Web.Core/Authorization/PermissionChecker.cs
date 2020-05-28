using Abp.Authorization;
using BLTS.Web.Authorization.Roles;
using BLTS.Web.Authorization.Users;

namespace BLTS.Web.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
