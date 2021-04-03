namespace BLTS.WebApi.Models
{
    public partial class NavigationMenuNavigationMenu
    {
        public long ParentNavigationMenuId { get; set; }
        public long ChildNavigationMenuId { get; set; }

        public virtual NavigationMenu ChildNavigationMenu { get; set; }
        public virtual NavigationMenu ParentNavigationMenu { get; set; }
    }
}
