using BLTS.WebApi.Models;

namespace BLTS.WebApi.DtoModels
{
    public class OperationalConfigurationPagedResultRequestDto : PagedResultRequestDtoEntity<OperationalConfiguration>
    {
        public OperationalConfigurationPagedResultRequestDto()
        {
            IncludeDeleted = false;
        }

        public long ApplicationId { get; set; }
        public bool IncludeDeleted { get; set; }
    }
}


