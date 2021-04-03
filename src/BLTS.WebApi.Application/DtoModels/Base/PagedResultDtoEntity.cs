using System.Collections.Generic;

namespace BLTS.WebApi.DtoModels
{
    public class PagedResultDtoEntity<T>
    {
        public PagedResultDtoEntity()
        {
        }
        public PagedResultDtoEntity(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}