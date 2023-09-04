using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Movie.Controllers
{
    public abstract class MovieControllerBase: AbpController
    {
        protected MovieControllerBase()
        {
            LocalizationSourceName = MovieConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
