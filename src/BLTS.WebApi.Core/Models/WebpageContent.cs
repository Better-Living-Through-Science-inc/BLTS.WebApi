using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class WebpageContent : Entity<long>
    {
        public WebpageContent()
        {
            NavigationMenuCollection = new HashSet<NavigationMenu>();
        }

        public string Title { get; set; }
        public string Metatag { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        public virtual ICollection<NavigationMenu> NavigationMenuCollection { get; set; }
    }
}
