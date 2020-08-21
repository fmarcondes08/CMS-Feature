using System.Threading.Tasks;
using Abp.Application.Services;
using FabricioAssignment.Sessions.Dto;

namespace FabricioAssignment.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
