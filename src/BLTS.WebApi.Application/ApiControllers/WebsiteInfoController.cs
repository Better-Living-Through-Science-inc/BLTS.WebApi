using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;

namespace BLTS.WebApi.ApiControllers
{
    public class WebsiteInfoController : ApiAuthorizedControllerBase<WebsiteInfo, WebsiteInfoDtoEntity, long, DeleteDtoEntity<long>>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public WebsiteInfoController(IApplicationLogTools applicationLogTools
                                   , IRepository<WebsiteInfo, long> repository
                                   , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
