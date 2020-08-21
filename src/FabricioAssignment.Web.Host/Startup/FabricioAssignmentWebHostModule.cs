using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FabricioAssignment.Configuration;

namespace FabricioAssignment.Web.Host.Startup
{
    [DependsOn(
       typeof(FabricioAssignmentWebCoreModule))]
    public class FabricioAssignmentWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FabricioAssignmentWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabricioAssignmentWebHostModule).GetAssembly());
        }
    }
}
