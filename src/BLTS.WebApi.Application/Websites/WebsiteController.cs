using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.Websites
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebsiteController : ApiController<Website, WebsiteDtoEntity, long, DeleteDtoEntity<long>>
    {
        public WebsiteController(IRepository<Website, long> repository
                               , IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
