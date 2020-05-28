using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BLTS.Web.EntityFrameworkCore
{
    public static class WebDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WebDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
