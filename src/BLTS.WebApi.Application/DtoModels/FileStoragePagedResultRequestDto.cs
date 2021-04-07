﻿using BLTS.WebApi.Models;

namespace BLTS.WebApi.DtoModels
{
    public class FileStoragePagedResultRequestDto : PagedResultRequestDtoEntity<FileStorage>
    {
        public bool IncludeDeleted { get; set; }
    }
}

