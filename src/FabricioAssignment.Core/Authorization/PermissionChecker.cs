using Abp.Authorization;
using FabricioAssignment.Authorization.Roles;
using FabricioAssignment.Authorization.Users;

namespace FabricioAssignment.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
