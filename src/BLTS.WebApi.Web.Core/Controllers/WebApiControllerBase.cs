using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BLTS.WebApi.Controllers
{
    public abstract class WebApiControllerBase: AbpController
    {
        protected WebApiControllerBase()
        {
            LocalizationSourceName = WebApiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
