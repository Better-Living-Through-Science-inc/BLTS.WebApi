using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace BLTS.WebApi.Websites
{
    [Authorize]
    public class WebsiteController : ApiControllerBase<Website, WebsiteDtoEntity, long, DeleteDtoEntity<long>>
    {
        public WebsiteController(IApplicationLogTools applicationLogTools
                               , IRepository<Website, long> repository
                               , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
