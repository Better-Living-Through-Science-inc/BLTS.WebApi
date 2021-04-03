namespace BLTS.WebApi.Models
{
    public partial class WebsiteNavigationMenu
    {
        public long WebsiteId { get; set; }
        public long NavigationMenuId { get; set; }

        public virtual NavigationMenu NavigationMenu { get; set; }
        public virtual Website Website { get; set; }
    }
}
