namespace BLTS.WebApi.DtoModels
{
    public partial class WebsiteDtoEntity : DtoEntity<long>
    {
        public WebsiteDtoEntity()
        {
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
    }
}
