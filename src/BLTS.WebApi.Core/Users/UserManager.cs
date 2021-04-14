using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BLTS.WebApi.Users
{
    public class UserManager
    {
        public UserManager()
        {
        }

        /// <summary>
        /// extracts and returns the group membership guids as a list of strings
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<string> GetUserGroupMembershipCollection(ClaimsPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).Claims
                                                  .Where(singleClaim => singleClaim.Type.Equals("groups"))
                                                  .Select(singleGroup => singleGroup.Value)
                                                  .ToList();

        }
    }
}
