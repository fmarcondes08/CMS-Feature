using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using FabricioAssignment.EntityFrameworkCore.Seed;

namespace FabricioAssignment.EntityFrameworkCore
{
    [DependsOn(
        typeof(FabricioAssignmentCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class FabricioAssignmentEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<FabricioAssignmentDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        FabricioAssignmentDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        FabricioAssignmentDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabricioAssignmentEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
