using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BLTS.Web.Roles.Dto;
using BLTS.Web.Users.Dto;

namespace BLTS.Web.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
