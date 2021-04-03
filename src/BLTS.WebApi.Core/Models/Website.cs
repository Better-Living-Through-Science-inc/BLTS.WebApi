using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class Website : Entity<long>
    {
        public Website()
        {
            ApplicationLogCollection = new HashSet<ApplicationLog>();
            OperationalConfigurationCollection = new HashSet<OperationalConfiguration>();
            WebsiteNavigationMenuCollection = new HashSet<WebsiteNavigationMenu>();
        }

        public string Name { get; set; }
        public string Metatag { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public string BaseUrl { get; set; }
        public string PocEmail { get; set; }
        public string PocNumber { get; set; }
        public string CssThemePath { get; set; }

        public virtual ICollection<ApplicationLog> ApplicationLogCollection { get; set; }
        public virtual ICollection<OperationalConfiguration> OperationalConfigurationCollection { get; set; }
        public virtual ICollection<WebsiteNavigationMenu> WebsiteNavigationMenuCollection { get; set; }
    }
}
