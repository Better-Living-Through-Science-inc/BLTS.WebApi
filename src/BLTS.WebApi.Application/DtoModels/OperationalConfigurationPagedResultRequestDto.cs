using BLTS.WebApi.Models;

namespace BLTS.WebApi.DtoModels
{
    public class OperationalConfigurationPagedResultRequestDto : PagedResultRequestDtoEntity<OperationalConfiguration>
    {
        public bool IncludeDeleted { get; set; }
    }
}


