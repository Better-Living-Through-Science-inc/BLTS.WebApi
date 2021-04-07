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
    public class WebsiteNavigationController : ApiControllerBase<NavigationMenu, NavigationMenuDtoEntity, long, DeleteDtoEntity<long>>
    {
        public WebsiteNavigationController(IApplicationLogTools applicationLogTools
                                         , IRepository<NavigationMenu, long> repository
                                         , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
