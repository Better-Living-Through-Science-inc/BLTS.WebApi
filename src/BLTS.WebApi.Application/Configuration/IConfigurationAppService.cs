using System.Threading.Tasks;
using BLTS.WebApi.Configuration.Dto;

namespace BLTS.WebApi.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
