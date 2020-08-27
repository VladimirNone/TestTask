using System.Threading.Tasks;
using ForInterview.Configuration.Dto;

namespace ForInterview.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
