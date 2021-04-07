using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;

namespace BLTS.WebApi.Web.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IPagedResultRequestEntity<Website>, PagedResultRequestDtoEntity<WebsiteDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<WebsiteDtoEntity>, IPagedResultRequestEntity<Website>>();
            CreateMap<IPagedResultEntity<Website>, PagedResultDtoEntity<WebsiteDtoEntity>>();
            CreateMap<PagedResultDtoEntity<WebsiteDtoEntity>, IPagedResultEntity<Website>>();
            CreateMap<Website, WebsiteDtoEntity>();
            CreateMap<WebsiteDtoEntity, Website>();
        }
    }
}
