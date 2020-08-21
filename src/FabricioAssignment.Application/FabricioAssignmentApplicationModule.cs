using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FabricioAssignment.Authorization;

namespace FabricioAssignment
{
    [DependsOn(
        typeof(FabricioAssignmentCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FabricioAssignmentApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FabricioAssignmentAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FabricioAssignmentApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
