using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ForInterview.EntityFrameworkCore
{
    public static class ForInterviewDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ForInterviewDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ForInterviewDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
