namespace BLTS.WebApi.DtoModels
{
    public class FileStoragePagedResultRequestDto : PagedResultRequestDtoEntity<FileStorageDto>
    {
        public bool IncludeDeleted { get; set; }
    }
}


