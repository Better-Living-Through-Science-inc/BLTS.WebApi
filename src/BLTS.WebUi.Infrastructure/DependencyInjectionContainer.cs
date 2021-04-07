using BLTS.WebApi.Infrastructure.AzureApi;
using BLTS.WebApi.Infrastructure.Database;
using BLTS.WebApi.Models;
using BLTS.WebUi.Infrastructure.FileStorages;
using Microsoft.Extensions.DependencyInjection;

namespace BLTS.WebApi.Infrastructure
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
            /*General Application Services*/
            _services.AddTransient<ApiAuthentication>();
            _services.AddHttpClient<ApiAuthentication>();
            _services.AddTransient<IAzureFileStorage, AzureFileStorage>();
            _services.AddTransient<IUnitOfWork<WebDbContext>, UnitOfWork<WebDbContext>>();

        }
    }
}
