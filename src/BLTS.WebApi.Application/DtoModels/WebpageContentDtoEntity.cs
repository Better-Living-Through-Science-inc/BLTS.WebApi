using BLTS.WebApi.DtoModels;

namespace BLTS.WebApi.Models
{
    public partial class WebpageContentDtoEntity : DtoEntity<long>
    {
        public WebpageContentDtoEntity()
        {
        }

        public string Title { get; set; }
        public string Metatag { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
    }
}
