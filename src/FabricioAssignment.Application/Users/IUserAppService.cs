using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FabricioAssignment.Roles.Dto;
using FabricioAssignment.Users.Dto;

namespace FabricioAssignment.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
