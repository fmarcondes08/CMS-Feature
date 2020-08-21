using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using System.Threading.Tasks;

namespace FabricioAssignment.CMSService
{
    public class ContentManager : IContentManager
    {
        private readonly IRepository<Content, int> _contentRepository;

        public ContentManager(IRepository<Content, int> contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<Content> CreateAsync(Content content)
        {
            return await _contentRepository.InsertAsync(content);
        }

        public async Task<Content> UpdateAsync(Content content)
        {
            return await _contentRepository.UpdateAsync(content);
        }
    }
}
