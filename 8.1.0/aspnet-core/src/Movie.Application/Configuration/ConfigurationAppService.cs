using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Movie.Configuration.Dto;

namespace Movie.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MovieAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
