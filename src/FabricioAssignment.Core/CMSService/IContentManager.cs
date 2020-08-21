using Abp.Domain.Services;
using System.Threading.Tasks;

namespace FabricioAssignment.CMSService
{
    public interface IContentManager : IDomainService
    {
        Task<Content> CreateAsync(Content content);
        Task<Content> UpdateAsync(Content content);
    }
}
