using System;

namespace BLTS.WebApi.Models
{
    public interface IUnitOfWork<TDbContext> : IDisposable
    {
        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        int Complete();
    }
}
