using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FabricioAssignment.EntityFrameworkCore
{
    public static class FabricioAssignmentDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FabricioAssignmentDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FabricioAssignmentDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
