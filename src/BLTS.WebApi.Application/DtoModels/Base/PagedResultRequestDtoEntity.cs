using System;
using System.ComponentModel.DataAnnotations;

namespace BLTS.WebApi.DtoModels
{
    public class PagedResultRequestDtoEntity
    {
        public PagedResultRequestDtoEntity()
        { 
        }

        /// <summary>
        /// take this many records
        /// </summary>
        [Range(1, long.MaxValue)]
        public long MaxResultCount { get; set; }
        /// <summary>
        /// skip this many records
        /// </summary>
        [Range(0, long.MaxValue)]
        public long SkipCount { get; set; }
        /// <summary>
        /// Comma separated list of Property Name and desc/asc
        /// </summary>
        public string SortRequest { get; set; }
    }

}
