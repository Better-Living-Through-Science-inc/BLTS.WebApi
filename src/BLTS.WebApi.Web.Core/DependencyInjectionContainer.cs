using AutoMapper;
using BLTS.WebApi.Calculations;
using BLTS.WebApi.Configurations;
using BLTS.WebApi.FileStorages;
using BLTS.WebApi.Infrastructure.Database;
using BLTS.WebApi.InfrastructureInterfaces;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
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
            _services.AddSingleton<ApplicationLogTools>();
            _services.AddSingleton<ConfigurationManager>();
            _services.AddTransient<FileStorageManager>();
            _services.AddTransient<IMapper, Mapper>();
            _services.AddTransient<UnitConversionLogic>();

            /*DB Repository Models*/
            _services.AddTransient<IRepository<ApplicationLog, long>, Repository<ApplicationLog, long>>();
            _services.AddTransient<IRepository<FileStorage, long>, Repository<FileStorage, long>>();
            _services.AddTransient<IRepository<NavigationMenu, long>, Repository<NavigationMenu, long>>();
            _services.AddTransient<IRepository<OperationalConfiguration, long>, Repository<OperationalConfiguration, long>>();
            _services.AddTransient<IRepository<WebpageContent, long>, Repository<WebpageContent, long>>();
            _services.AddTransient<IRepository<Website, long>, Repository<Website, long>>();

            /*Api Repository Models*/
            //_services.AddTransient<IApiRepository<Weather, WeatherDto, CreateUpdateWeatherDto, long>, ApiRepository<Weather, WeatherDto, CreateUpdateWeatherDto, long>>();

        }
    }
}
