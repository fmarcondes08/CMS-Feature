using System.Threading.Tasks;
using FabricioAssignment.Configuration.Dto;

namespace FabricioAssignment.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
