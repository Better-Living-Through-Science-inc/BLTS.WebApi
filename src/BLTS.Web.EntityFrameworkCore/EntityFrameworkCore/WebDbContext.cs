using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BLTS.Web.Authorization.Roles;
using BLTS.Web.Authorization.Users;
using BLTS.Web.MultiTenancy;

namespace BLTS.Web.EntityFrameworkCore
{
    public class WebDbContext : AbpZeroDbContext<Tenant, Role, User, WebDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }
    }
}
