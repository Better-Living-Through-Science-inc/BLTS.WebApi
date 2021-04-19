﻿using BLTS.WebApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLTS.WebApi.Infrastructure.Database
{
    public class PagedResultRequestEntity<TEntity> : IPagedResultRequestEntity<TEntity>
    {
        public PagedResultRequestEntity()
        {
            MaxResultCount = 100;
            SkipCount = 0;
            SortRequest = "Id Desc";
        }

        /// <summary>
        /// take this many records
        /// </summary>
        [Range(1, int.MaxValue)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// skip this many records
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        /// <summary>
        /// Comma separated list of Property Name and desc/asc
        /// </summary>
        public string SortRequest { get; set; }
        /// <summary>
        /// partially populated object used as a query filter
        /// </summary>
        public TEntity ObjectFilter { get; set; }
    }

}
