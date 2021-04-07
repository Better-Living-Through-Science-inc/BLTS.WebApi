using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.Websites
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ApiControllerBase<Application, ApplicationDtoEntity, long, DeleteDtoEntity<long>>
    {
        public ApplicationController(IApplicationLogTools applicationLogTools
                                   , IRepository<Application, long> repository
                                   , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
