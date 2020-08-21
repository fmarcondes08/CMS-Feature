using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FabricioAssignment.CMSService
{
    [Table("AppContent")]
    public class Content : Entity<int>
    {
        public const int MaxPageNameLength = 128;
        public const int MaxPageContentLength = 2048;

        [Required]
        [StringLength(MaxPageNameLength)]
        public virtual string PageName { get; protected set; }

        [StringLength(MaxPageContentLength)]
        public virtual string PageContent { get; protected set; }

        protected Content()
        {

        }

        public static Content Create(int id, string PageName, string PageContent)
        {
            var @content = new Content
            {
                Id = id,
                PageName = PageName,
                PageContent = PageContent,
            };

            return @content;
        }
    }
}
