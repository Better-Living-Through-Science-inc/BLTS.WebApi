using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;

namespace BLTS.WebApi.Web.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<IPagedResultRequestEntity<ApplicationInfo>, PagedResultRequestDtoEntity<ApplicationInfoDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<ApplicationInfoDtoEntity>, IPagedResultRequestEntity<ApplicationInfo>>();
            CreateMap<IPagedResultEntity<ApplicationInfo>, PagedResultDtoEntity<ApplicationInfoDtoEntity>>();
            CreateMap<PagedResultDtoEntity<ApplicationInfoDtoEntity>, IPagedResultEntity<ApplicationInfo>>();
            CreateMap<ApplicationInfo, ApplicationInfoDtoEntity>();
            CreateMap<ApplicationInfoDtoEntity, ApplicationInfo>();

            CreateMap<IPagedResultRequestEntity<NavigationMenu>, PagedResultRequestDtoEntity<NavigationMenuDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<NavigationMenuDtoEntity>, IPagedResultRequestEntity<NavigationMenu>>();
            CreateMap<IPagedResultEntity<NavigationMenu>, PagedResultDtoEntity<NavigationMenuDtoEntity>>();
            CreateMap<PagedResultDtoEntity<NavigationMenuDtoEntity>, IPagedResultEntity<NavigationMenu>>();
            CreateMap<NavigationMenu, NavigationMenuDtoEntity>();
            CreateMap<NavigationMenuDtoEntity, NavigationMenu>();
            CreateMap<NavigationMenu, WebsiteNavigationMenuDtoEntity>();

            CreateMap<IPagedResultRequestEntity<WebpageContent>, PagedResultRequestDtoEntity<WebpageContentDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<WebpageContentDtoEntity>, IPagedResultRequestEntity<WebpageContent>>();
            CreateMap<IPagedResultEntity<WebpageContent>, PagedResultDtoEntity<WebpageContentDtoEntity>>();
            CreateMap<PagedResultDtoEntity<WebpageContentDtoEntity>, IPagedResultEntity<WebpageContent>>();
            CreateMap<WebpageContent, WebpageContentDtoEntity>();
            CreateMap<WebpageContentDtoEntity, WebpageContent>();

            CreateMap<IPagedResultRequestEntity<WebsiteInfo>, PagedResultRequestDtoEntity<WebsiteInfoDtoEntity>>();
            CreateMap<PagedResultRequestDtoEntity<WebsiteInfoDtoEntity>, IPagedResultRequestEntity<WebsiteInfo>>();
            CreateMap<IPagedResultEntity<WebsiteInfo>, PagedResultDtoEntity<WebsiteInfoDtoEntity>>();
            CreateMap<PagedResultDtoEntity<WebsiteInfoDtoEntity>, IPagedResultEntity<WebsiteInfo>>();
            CreateMap<WebsiteInfo, WebsiteInfoDtoEntity>();
            CreateMap<WebsiteInfoDtoEntity, WebsiteInfo>();
        }
    }
}
