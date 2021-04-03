using System.Collections.Generic;

namespace BLTS.WebApi.Infrastructure.AzureApi.Models
{
    public class ContentWrapper<TEntityDto>
    {
        public int TotalCount { get; set; }
        public List<TEntityDto> Items { get; set; }
    }
}
