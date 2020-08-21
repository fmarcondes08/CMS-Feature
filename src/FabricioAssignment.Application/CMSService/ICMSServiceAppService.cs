using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FabricioAssignment.CMSService.Dto;
using System.Threading.Tasks;

namespace FabricioAssignment.CMSService
{
    public interface ICMSServiceAppService : IApplicationService
    {
        Task<ContentOutput> GetCMSContent(EntityDto<int> input);

        Task<ContentOutput> InsertOrUpdateCSMContent(ContentDto input);

        Task<ListResultDto<ContentListDto>> GetAll();
    }
}
