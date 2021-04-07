using BLTS.WebApi.DtoModels;
using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class NavigationMenuDtoEntity : DtoEntity<long>
    {
        public NavigationMenuDtoEntity()
        {
            IsEnabled = true;
            ChildNavigationMenuCollection = new HashSet<NavigationMenuDtoEntity>();
        }

        public long WebpageContentId { get; set; }
        public string DisplayText { get; set; }
        public string ToolTip { get; set; }
        public string SubPath { get; set; }
        public string IconClass { get; set; }
        public bool IsAuthorizationRequired { get; set; }
        public bool IsEnabled { get; set; }

        public virtual WebpageContentDtoEntity WebpageContent { get; set; }
        public virtual ICollection<NavigationMenuDtoEntity> ChildNavigationMenuCollection { get; set; }
    }
}
