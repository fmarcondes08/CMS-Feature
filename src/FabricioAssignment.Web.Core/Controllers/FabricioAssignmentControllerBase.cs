using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FabricioAssignment.Controllers
{
    public abstract class FabricioAssignmentControllerBase: AbpController
    {
        protected FabricioAssignmentControllerBase()
        {
            LocalizationSourceName = FabricioAssignmentConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
