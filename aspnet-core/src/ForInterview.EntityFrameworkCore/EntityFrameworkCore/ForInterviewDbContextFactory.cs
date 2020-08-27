using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ForInterview.Configuration;
using ForInterview.Web;

namespace ForInterview.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ForInterviewDbContextFactory : IDesignTimeDbContextFactory<ForInterviewDbContext>
    {
        public ForInterviewDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ForInterviewDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ForInterviewDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ForInterviewConsts.ConnectionStringName));

            return new ForInterviewDbContext(builder.Options);
        }
    }
}
