using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BLTS.WebApi.Authorization.Roles;
using BLTS.WebApi.Authorization.Users;
using BLTS.WebApi.MultiTenancy;

namespace BLTS.WebApi.EntityFrameworkCore
{
    public class WebApiDbContext : AbpZeroDbContext<Tenant, Role, User, WebApiDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }
    }
}
