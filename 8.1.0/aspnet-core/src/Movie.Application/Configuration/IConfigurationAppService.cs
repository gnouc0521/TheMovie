using System.Threading.Tasks;
using Movie.Configuration.Dto;

namespace Movie.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
