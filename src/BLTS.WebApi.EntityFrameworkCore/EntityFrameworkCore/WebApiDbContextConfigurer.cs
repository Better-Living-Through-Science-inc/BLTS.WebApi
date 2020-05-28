using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BLTS.WebApi.EntityFrameworkCore
{
    public static class WebApiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WebApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
