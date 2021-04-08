using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace BLTS.WebApi.Websites
{
    [Authorize]
    public class ApplicationController : ApiControllerBase<Application, ApplicationDtoEntity, long, DeleteDtoEntity<long>>
    {
        public ApplicationController(IApplicationLogTools applicationLogTools
                                   , IRepository<Application, long> repository
                                   , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
