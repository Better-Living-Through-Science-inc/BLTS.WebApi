using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BLTS.Web.Configuration;
using BLTS.Web.Web;

namespace BLTS.Web.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WebDbContextFactory : IDesignTimeDbContextFactory<WebDbContext>
    {
        public WebDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WebDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WebConsts.ConnectionStringName));

            return new WebDbContext(builder.Options);
        }
    }
}
