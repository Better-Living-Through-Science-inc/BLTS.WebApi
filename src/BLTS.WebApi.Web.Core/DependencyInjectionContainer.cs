using AutoMapper;
using BLTS.WebApi.Calculations;
using BLTS.WebApi.CmsOutput;
using BLTS.WebApi.Configurations;
using BLTS.WebApi.FileStorages;
using BLTS.WebApi.Infrastructure.Database;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using BLTS.WebApi.Users;
using BLTS.WebApi.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace BLTS.WebApi.Web.Core
{
    /// <summary>
    /// dependency injection service
    /// </summary>
    public class DependencyInjectionContainer
    {
        IServiceCollection _services;

        public DependencyInjectionContainer(IServiceCollection services)
        {
            _services = services;
        }

        /// <summary>
        /// add all object to the dependency injection service provider
        /// </summary>
        /// <returns></returns>
        public void Initialize()
        {
            /*Application Services*/
            _services.AddTransient<IApplicationLogTools, ApplicationLogTools>();
            _services.AddTransient<CmsOutputManager>();
            _services.AddTransient<ConfigurationManager>();
            _services.AddTransient<FileStorageManager>();
            _services.AddTransient<IMapper, Mapper>();
            _services.AddTransient<ReflectionTools>();
            _services.AddTransient<StringUtilities>();
            _services.AddTransient<UnitConversionLogic>();
            _services.AddTransient<UserManager>();


            /*DB Repository Models*/
            _services.AddTransient<IRepository<ActiveDirectoryGroup, long>, Repository<ActiveDirectoryGroup, long, WebDbContext>>();
            _services.AddTransient<IRepository<ApplicationInfo, long>, Repository<ApplicationInfo, long, WebDbContext>>();
            _services.AddTransient<IRepository<ApplicationLog, long>, Repository<ApplicationLog, long, WebDbContext>>();
            _services.AddTransient<IRepository<ApplicationPermission, long>, Repository<ApplicationPermission, long, WebDbContext>>();
            _services.AddTransient<IRepository<FileStorage, long>, Repository<FileStorage, long, WebDbContext>>();
            _services.AddTransient<IRepository<FileStoragePermission, long>, Repository<FileStoragePermission, long, WebDbContext>>();
            _services.AddTransient<IRepository<NavigationMenu, long>, Repository<NavigationMenu, long, WebDbContext>>();
            _services.AddTransient<IRepository<OperationalConfiguration, long>, Repository<OperationalConfiguration, long, WebDbContext>>();
            _services.AddTransient<IRepository<WebpageContent, long>, Repository<WebpageContent, long, WebDbContext>>();
            _services.AddTransient<IRepository<WebpageContentPermission, long>, Repository<WebpageContentPermission, long, WebDbContext>>();
            _services.AddTransient<IRepository<WebsiteInfo, long>, Repository<WebsiteInfo, long, WebDbContext>>();
            _services.AddTransient<IRepository<WebsitePermission, long>, Repository<WebsitePermission, long, WebDbContext>>();
            //NavigationMenuNavigationMenu
            //WebsiteNavigationMenu

            /*Api Repository Models*/
            //_services.AddTransient<IApiRepository<Weather, WeatherDto, CreateUpdateWeatherDto, long>, ApiRepository<Weather, WeatherDto, CreateUpdateWeatherDto, long>>();
        }

    }
}
