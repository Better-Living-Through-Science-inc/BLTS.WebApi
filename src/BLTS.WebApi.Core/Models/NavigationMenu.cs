using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class NavigationMenu : Entity<long>
    {
        public NavigationMenu()
        {
            IsEnabled = true;
            ChildNavigationMenuCollection = new HashSet<NavigationMenuNavigationMenu>();
            ParentNavigationMenuCollection = new HashSet<NavigationMenuNavigationMenu>();
            WebsiteNavigationMenuCollection = new HashSet<WebsiteNavigationMenu>();
        }

        public long WebpageContentId { get; set; }
        public string DisplayText { get; set; }
        public string ToolTip { get; set; }
        public string SubPath { get; set; }
        public string IconClass { get; set; }
        public bool IsAuthorizationRequired { get; set; }
        public bool IsEnabled { get; set; }

        public virtual WebpageContent WebpageContent { get; set; }
        public virtual ICollection<NavigationMenuNavigationMenu> ChildNavigationMenuCollection { get; set; }
        public virtual ICollection<NavigationMenuNavigationMenu> ParentNavigationMenuCollection { get; set; }
        public virtual ICollection<WebsiteNavigationMenu> WebsiteNavigationMenuCollection { get; set; }
    }
}
