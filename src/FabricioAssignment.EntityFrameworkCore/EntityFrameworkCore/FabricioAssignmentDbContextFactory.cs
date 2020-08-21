using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FabricioAssignment.Configuration;
using FabricioAssignment.Web;

namespace FabricioAssignment.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FabricioAssignmentDbContextFactory : IDesignTimeDbContextFactory<FabricioAssignmentDbContext>
    {
        public FabricioAssignmentDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FabricioAssignmentDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FabricioAssignmentDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FabricioAssignmentConsts.ConnectionStringName));

            return new FabricioAssignmentDbContext(builder.Options);
        }
    }
}
