using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.Websites
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebsiteNavigation : ApiController<NavigationMenu, NavigationMenuDtoEntity, long, DeleteDtoEntity<long>>
    {
        public WebsiteNavigation(IRepository<NavigationMenu, long> repository
                               , IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
