﻿namespace BLTS.WebApi.DtoModels
{
    public partial class ApplicationDtoEntity : DtoEntity<long>
    {
        public ApplicationDtoEntity()
        {
        }

        public string Name { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PocEmail { get; set; }
        public string PocNumber { get; set; }
    }
}
