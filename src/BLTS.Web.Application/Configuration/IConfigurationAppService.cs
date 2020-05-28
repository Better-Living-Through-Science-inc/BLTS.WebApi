using System.Threading.Tasks;
using BLTS.Web.Configuration.Dto;

namespace BLTS.Web.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
