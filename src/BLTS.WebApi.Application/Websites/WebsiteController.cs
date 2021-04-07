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
    public class WebsiteController : ApiControllerBase<Application, WebsiteDtoEntity, long, DeleteDtoEntity<long>>
    {
        public WebsiteController(IApplicationLogTools applicationLogTools
                               , IRepository<Application, long> repository
                               , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
