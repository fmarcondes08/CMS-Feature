using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FabricioAssignment.Authorization.Roles;
using FabricioAssignment.Authorization.Users;
using FabricioAssignment.MultiTenancy;
using FabricioAssignment.CMSService;

namespace FabricioAssignment.EntityFrameworkCore
{
    public class FabricioAssignmentDbContext : AbpZeroDbContext<Tenant, Role, User, FabricioAssignmentDbContext>
    {
        public virtual DbSet<Content> Content { get; set; }
        /* Define a DbSet for each entity of the application */

        public FabricioAssignmentDbContext(DbContextOptions<FabricioAssignmentDbContext> options)
            : base(options)
        {
        }
    }
}
