﻿namespace BLTS.WebApi.DtoModels
{
    public partial class WebsiteInfoDtoEntity : DtoEntity<long>
    {
        public WebsiteInfoDtoEntity()
        {
        }

        public long ApplicationId { get; set; }
        public string Name { get; set; }
        public string Metatag { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public string BaseUrl { get; set; }
        public string CssThemePath { get; set; }
    }
}
