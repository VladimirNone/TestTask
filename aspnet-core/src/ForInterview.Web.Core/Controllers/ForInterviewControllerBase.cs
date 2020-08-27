using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ForInterview.Controllers
{
    public abstract class ForInterviewControllerBase: AbpController
    {
        protected ForInterviewControllerBase()
        {
            LocalizationSourceName = ForInterviewConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
