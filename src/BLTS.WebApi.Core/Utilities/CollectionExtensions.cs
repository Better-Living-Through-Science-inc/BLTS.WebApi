using BLTS.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BLTS.WebApi.Utilities
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// sorts and pages the result set or returns unsorted when pagedResultRequestEntity is null
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="searchQuery"></param>
        /// <param name="pagedResultRequestEntity"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> PagedSorted<TEntity>(this IQueryable<TEntity> searchQuery, IPagedResultRequestEntity<TEntity> pagedResultRequestEntity)
        {
            if (pagedResultRequestEntity == null)
                return searchQuery;

            if (string.IsNullOrWhiteSpace(pagedResultRequestEntity.SortRequest))
                return searchQuery;
            else
                return searchQuery.OrderBy(pagedResultRequestEntity.SortRequest)
                                  .Skip(pagedResultRequestEntity.SkipCount)
                                  .Take(pagedResultRequestEntity.MaxResultCount);
        }

        /// <summary>
        /// sorts and pages the result set or returns unsorted when pagedResultRequestEntity is null
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="searchQuery"></param>
        /// <param name="pagedResultRequestEntity"></param>
        /// <returns></returns>
        public static IEnumerable<TEntity> PagedSorted<TEntity>(this IEnumerable<TEntity> searchQuery, IPagedResultRequestEntity<TEntity> pagedResultRequestEntity)
        {
            if (pagedResultRequestEntity == null)
                return searchQuery;

            if (string.IsNullOrWhiteSpace(pagedResultRequestEntity.SortRequest))
                return searchQuery;
            else
                return searchQuery.AsQueryable().OrderBy(pagedResultRequestEntity.SortRequest)
                                                .Skip(pagedResultRequestEntity.SkipCount)
                                                .Take(pagedResultRequestEntity.MaxResultCount);
        }


    }

}
