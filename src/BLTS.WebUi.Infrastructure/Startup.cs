using BLTS.WebApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLTS.WebApi.Infrastructure
{
    public class Startup
    {
        IServiceCollection _services;
        IConfiguration _configuration;

        public Startup(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Initialize()
        {
            _services.AddDbContext<WebDbContext>(options => options.UseSqlServer(
                                                _configuration.GetConnectionString("Default"),
                                                builder => builder.MigrationsAssembly(typeof(WebDbContext).Assembly.FullName)));

            DependencyInjectionContainer dependencyInjectionStartup = new DependencyInjectionContainer(_services);
            dependencyInjectionStartup.Initialize();
        }
    }
}
