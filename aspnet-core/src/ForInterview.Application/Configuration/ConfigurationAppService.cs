using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ForInterview.Configuration.Dto;

namespace ForInterview.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ForInterviewAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
