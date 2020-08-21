using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FabricioAssignment.Configuration;
using FabricioAssignment.EntityFrameworkCore;
using FabricioAssignment.Migrator.DependencyInjection;

namespace FabricioAssignment.Migrator
{
    [DependsOn(typeof(FabricioAssignmentEntityFrameworkModule))]
    public class FabricioAssignmentMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FabricioAssignmentMigratorModule(FabricioAssignmentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(FabricioAssignmentMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FabricioAssignmentConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabricioAssignmentMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
