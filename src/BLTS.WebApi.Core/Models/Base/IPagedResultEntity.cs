using System.Collections.Generic;

namespace BLTS.WebApi.Models
{
    public interface IPagedResultEntity<TEntity>
    {
        List<TEntity> ItemCollection { get; set; }
        long TotalCount { get; set; }
    }
}