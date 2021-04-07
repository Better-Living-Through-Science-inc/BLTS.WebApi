using BLTS.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BLTS.WebApi.Infrastructure.Database
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<TDbContext>();
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Releases the allocated resources for this context.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
