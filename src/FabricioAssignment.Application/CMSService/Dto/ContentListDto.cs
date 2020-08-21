using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FabricioAssignment.CMSService;

namespace FabricioAssignment.CMSService.Dto
{
    [AutoMapFrom(typeof(Content))]
    public class ContentListDto : EntityDto<int>
    {
        public string PageName { get; set; }
        public string PageContent { get; set; }
    }
}
