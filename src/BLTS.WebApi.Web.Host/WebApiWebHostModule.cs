using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using BLTS.WebApi.Configurations;

namespace BLTS.WebApi.Web
{
    public class WebApiWebHostModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WebApiWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

    }
}
