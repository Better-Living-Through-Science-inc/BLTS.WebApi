using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;

namespace BLTS.WebApi.ApiControllers
{
    public class WebsiteNavigationController : ApiAuthorizedControllerBase<NavigationMenu, NavigationMenuDtoEntity, long, DeleteDtoEntity<long>>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public WebsiteNavigationController(IApplicationLogTools applicationLogTools
                                         , IRepository<NavigationMenu, long> repository
                                         , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }

    }
}
