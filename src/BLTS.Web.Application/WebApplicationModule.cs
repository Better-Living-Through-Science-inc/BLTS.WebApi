using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BLTS.Web.Authorization;

namespace BLTS.Web
{
    [DependsOn(
        typeof(WebCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WebAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WebApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
