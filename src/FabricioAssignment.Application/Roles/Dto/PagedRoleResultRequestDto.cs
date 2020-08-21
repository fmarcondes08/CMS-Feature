using Abp.Application.Services.Dto;

namespace FabricioAssignment.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

