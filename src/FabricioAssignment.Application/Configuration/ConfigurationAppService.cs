using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FabricioAssignment.Configuration.Dto;

namespace FabricioAssignment.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FabricioAssignmentAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
