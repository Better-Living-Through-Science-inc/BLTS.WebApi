using BLTS.WebApi.DtoModels;

namespace BLTS.WebApi.FileStorages.Dto
{
    public class FileStoragePagedResultRequestDto : PagedResultRequestDtoEntity
    {
        public bool IncludeDeleted { get; set; }
    }
}


