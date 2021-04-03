﻿using System;

namespace BLTS.WebApi.InfrastructureInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
