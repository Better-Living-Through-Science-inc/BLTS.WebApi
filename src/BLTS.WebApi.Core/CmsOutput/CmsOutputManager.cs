using BLTS.WebApi.Configurations;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using BLTS.WebApi.Users;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace BLTS.WebApi.CmsOutput
{
    public class CmsOutputManager
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly IRepository<NavigationMenu, long> _repositoryNavigationMenu;
        private readonly IRepository<WebsiteInfo, long> _repositoryWebsiteInfo;
        private readonly ConfigurationManager _configurationManager;
        private readonly UserManager _userManager;

        public CmsOutputManager(IApplicationLogTools applicationLogTools
                              , IRepository<NavigationMenu, long> repositoryNavigationMenu
                              , IRepository<WebsiteInfo, long> repositoryWebsiteInfo
                              , ConfigurationManager configurationManager
                              , UserManager userManager)
        {
            _applicationLogTools = applicationLogTools;
            _repositoryNavigationMenu = repositoryNavigationMenu;
            _repositoryWebsiteInfo = repositoryWebsiteInfo;
            _configurationManager = configurationManager;
            _userManager = userManager;
        }

        /// <summary>
        /// returns the base information for a website
        /// </summary>
        /// <param name="websiteBaseUrl"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public WebsiteInfo GetWebsiteInformation(string websiteBaseUrl, ClaimsPrincipal user)
        {
            List<string> userGroupMembershipCollection = _userManager.GetUserGroupMembershipCollection(user);

            WebsiteInfo authorizedWebsiteInfo = _repositoryWebsiteInfo.Get(singleWebsiteInfo => singleWebsiteInfo.BaseUrl == websiteBaseUrl
                                                                                             && singleWebsiteInfo.IsEnabled == true
                                                                                             && (singleWebsiteInfo.IsAuthorizationRequired == false
                                                                                             || singleWebsiteInfo.WebsitePermissionCollection.Any(singlePermission => singlePermission.IsEnabled == true
                                                                                                                                                                   && userGroupMembershipCollection.Contains(singlePermission.ActiveDirectoryGroup.GroupSid)
                                                                                                                                                 )
                                                                                                 )
                                                                           )
                                                                      .FirstOrDefault();//correct site or null

            return authorizedWebsiteInfo;
        }

        /// <summary>
        /// returns the nav menus for a website
        /// </summary>
        /// <param name="websiteBaseUrl"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<NavigationMenu> GetWebsiteNavigationMenu(string websiteBaseUrl, ClaimsPrincipal user)
        {
            List<string> userGroupMembershipCollection = _userManager.GetUserGroupMembershipCollection(user);

            Dictionary<long, List<NavigationMenu>> authorizedMenuDictionary =
                //filter permissable menus
                _repositoryNavigationMenu.Get(navigationMenu => navigationMenu.IsDeleted == false
                                                             && navigationMenu.IsEnabled == true
                                                             && (navigationMenu.WebpageContent.IsAuthorizationRequired == false
                                                              || navigationMenu.WebpageContent.WebpageContentPermissionCollection.Any(singlePermission => singlePermission.IsEnabled == true
                                                                                                                                              && userGroupMembershipCollection.Contains(singlePermission.ActiveDirectoryGroup.GroupSid)
                                                                                                                                      )
                                                                )
                                             )
               //filter menus for permissable website
               .Where(navigationMenu => navigationMenu.WebsiteNavigationMenuCollection.Any(websiteNavigationMenu => websiteNavigationMenu.WebsiteInfo.BaseUrl == websiteBaseUrl
                                                                                                                 && websiteNavigationMenu.WebsiteInfo.IsEnabled == true
                                                                                                                 && (websiteNavigationMenu.WebsiteInfo.IsAuthorizationRequired == false
                                                                                                                 || websiteNavigationMenu.WebsiteInfo.WebsitePermissionCollection.Any(singlePermission => singlePermission.IsEnabled == true
                                                                                                                                                                                                       && userGroupMembershipCollection.Contains(singlePermission.ActiveDirectoryGroup.GroupSid)
                                                                                                                                                                                      )
                                                                                                                     )
                                                                                           )
                     )
               .AsEnumerable<NavigationMenu>()
               //generate groups based on navigation parents
               .GroupBy(navigationMenu => navigationMenu.ParentNavigationMenuId)
               .ToDictionary(navigationMenuGroup => navigationMenuGroup.Key
                           , navigationMenuGroup => navigationMenuGroup.ToList());


            //assign children to parents and return user authorized website menu
            if (authorizedMenuDictionary.ContainsKey(0))
            {
                authorizedMenuDictionary[0].ForEach(navigationMenu => navigationMenu.ChildNavigationMenuCollection = authorizedMenuDictionary.ContainsKey(navigationMenu.Id) ? authorizedMenuDictionary[navigationMenu.Id] : new List<NavigationMenu>());
                return authorizedMenuDictionary[0];
            }
            else
                return new List<NavigationMenu>();
        }
    }
}
