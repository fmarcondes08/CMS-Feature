using Abp.AutoMapper;
using FabricioAssignment.CMSService;
using System.ComponentModel.DataAnnotations;

namespace FabricioAssignment.CMSService.Dto
{
    [AutoMapTo(typeof(Content))]
    public class ContentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(Content.MaxPageNameLength)]
        public string PageName { get; set; }

        [StringLength(Content.MaxPageContentLength)]
        public string PageContent { get; set; }
    }
}
