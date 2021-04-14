using BLTS.WebApi.Configurations;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Security.Principal;

namespace BLTS.WebApi.WebsiteNavigations
{
    public class WebsiteNavigationMenuManager
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly IRepository<NavigationMenu, long> _repositoryNavigationMenu;
        private readonly IRepository<WebsiteInfo, long> _repositoryWebsiteInfo;
        private readonly ConfigurationManager _configurationManager;

        public WebsiteNavigationMenuManager(IApplicationLogTools applicationLogTools
                                          , IRepository<NavigationMenu, long> repositoryNavigationMenu
                                          , IRepository<WebsiteInfo, long> repositoryWebsiteInfo
                                          , ConfigurationManager configurationManager)
        {
            _applicationLogTools = applicationLogTools;
            _repositoryNavigationMenu = repositoryNavigationMenu;
            _repositoryWebsiteInfo = repositoryWebsiteInfo;
            _configurationManager = configurationManager;
        }

        public List<NavigationMenu> GetWebsiteNavigationMenu(string websiteBaseUrl, ClaimsPrincipal user)
        {
            List<string> userGroupMembershipCollection = ((ClaimsIdentity)user.Identity).Claims.Where(x => x.Type.Equals("groups")).Select(singleGroup => singleGroup.Value).ToList();

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
