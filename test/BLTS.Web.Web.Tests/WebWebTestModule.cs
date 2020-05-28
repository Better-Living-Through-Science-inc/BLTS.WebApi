using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BLTS.Web.EntityFrameworkCore;
using BLTS.Web.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace BLTS.Web.Web.Tests
{
    [DependsOn(
        typeof(WebWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WebWebTestModule : AbpModule
    {
        public WebWebTestModule(WebEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WebWebMvcModule).Assembly);
        }
    }
}