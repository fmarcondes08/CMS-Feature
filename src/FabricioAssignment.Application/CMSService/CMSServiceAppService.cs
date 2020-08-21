using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using Abp.UI;
using FabricioAssignment.CMSService.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabricioAssignment.CMSService
{
    [AbpAuthorize]
    public class CMSServiceAppService : FabricioAssignmentAppServiceBase, ICMSServiceAppService
    {
        private readonly IContentManager _contentManager;
        private readonly IRepository<Content, int> _contentRepository;
        private readonly IObjectMapper _objectMapper;

        public CMSServiceAppService(
            IContentManager contentManager,
            IRepository<Content, int> contentRepository,
            IObjectMapper objectMapper)
        {
            _contentManager = contentManager;
            _contentRepository = contentRepository;
            _objectMapper = objectMapper;
        }

        public async Task<ListResultDto<ContentListDto>> GetAll()
        {
            var contents = await _contentRepository
                .GetAll()
                .OrderByDescending(e => e.Id)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<ContentListDto>(_objectMapper.Map<List<ContentListDto>>(contents));
        }

        public async Task<ContentOutput> GetCMSContent(EntityDto<int> input)
        {
            var content = await _contentRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (content == null)
            {
                throw new UserFriendlyException("Page not found!");
            }

            return _objectMapper.Map<ContentOutput>(content);
        }

        public async Task<ContentOutput> InsertOrUpdateCSMContent(ContentDto input)
        {
            var cms = await _contentRepository.FirstOrDefaultAsync(input.Id);
            if (cms == null)
            {
                var content = Content.Create(input.Id, input.PageName, input.PageContent);
                var newContent = await _contentManager.CreateAsync(content);
                return _objectMapper.Map<ContentOutput>(newContent);
            }
            else
            {
                _objectMapper.Map(input, cms);
                var updateContent = await _contentManager.UpdateAsync(cms);
                return _objectMapper.Map<ContentOutput>(updateContent);
            }
        }
    }
}
