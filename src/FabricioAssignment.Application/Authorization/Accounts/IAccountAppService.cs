using System.Threading.Tasks;
using Abp.Application.Services;
using FabricioAssignment.Authorization.Accounts.Dto;

namespace FabricioAssignment.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
