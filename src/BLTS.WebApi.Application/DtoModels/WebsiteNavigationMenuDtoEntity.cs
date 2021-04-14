using BLTS.WebApi.DtoModels;
using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public partial class WebsiteNavigationMenuDtoEntity : DtoEntity<long>
    {
        public WebsiteNavigationMenuDtoEntity()
        {
            ChildNavigationMenuCollection = new List<WebsiteNavigationMenuDtoEntity>();
        }

        public string DisplayText { get; set; }
        public string ToolTip { get; set; }
        public string SubPath { get; set; }
        public string IconClass { get; set; }

        public virtual List<WebsiteNavigationMenuDtoEntity> ChildNavigationMenuCollection { get; set; }
    }
}
