using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;

namespace BLTS.WebApi.Web.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<IPagedResultRequestEntity<Application>, PagedResultRequestDtoEntity<ApplicationDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<ApplicationDtoEntity>, IPagedResultRequestEntity<Application>>();
            CreateMap<IPagedResultEntity<Application>, PagedResultDtoEntity<ApplicationDtoEntity>>();
            CreateMap<PagedResultDtoEntity<ApplicationDtoEntity>, IPagedResultEntity<Application>>();
            CreateMap<Application, ApplicationDtoEntity>();
            CreateMap<ApplicationDtoEntity, Application>();

            CreateMap<IPagedResultRequestEntity<NavigationMenu>, PagedResultRequestDtoEntity<NavigationMenuDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<NavigationMenuDtoEntity>, IPagedResultRequestEntity<NavigationMenu>>();
            CreateMap<IPagedResultEntity<NavigationMenu>, PagedResultDtoEntity<NavigationMenuDtoEntity>>();
            CreateMap<PagedResultDtoEntity<NavigationMenuDtoEntity>, IPagedResultEntity<NavigationMenu>>();
            CreateMap<NavigationMenu, NavigationMenuDtoEntity>();
            CreateMap<NavigationMenuDtoEntity, NavigationMenu>();

            CreateMap<IPagedResultRequestEntity<WebpageContent>, PagedResultRequestDtoEntity<WebpageContentDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<WebpageContentDtoEntity>, IPagedResultRequestEntity<WebpageContent>>();
            CreateMap<IPagedResultEntity<WebpageContent>, PagedResultDtoEntity<WebpageContentDtoEntity>>();
            CreateMap<PagedResultDtoEntity<WebpageContentDtoEntity>, IPagedResultEntity<WebpageContent>>();
            CreateMap<WebpageContent, WebpageContentDtoEntity>();
            CreateMap<WebpageContentDtoEntity, WebpageContent>();

            CreateMap<IPagedResultRequestEntity<Website>, PagedResultRequestDtoEntity<WebsiteDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<WebsiteDtoEntity>, IPagedResultRequestEntity<Website>>();
            CreateMap<IPagedResultEntity<Website>, PagedResultDtoEntity<WebsiteDtoEntity>>();
            CreateMap<PagedResultDtoEntity<WebsiteDtoEntity>, IPagedResultEntity<Website>>();
            CreateMap<Website, WebsiteDtoEntity>();
            CreateMap<WebsiteDtoEntity, Website>();
        }
    }
}
