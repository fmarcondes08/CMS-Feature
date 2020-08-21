using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FabricioAssignment.MultiTenancy.Dto;

namespace FabricioAssignment.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

