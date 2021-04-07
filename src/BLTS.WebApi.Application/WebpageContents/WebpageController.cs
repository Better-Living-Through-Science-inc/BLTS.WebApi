using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.WebpageContents
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Webpage : ApiControllerBase<WebpageContent, WebpageContentDtoEntity, long, DeleteDtoEntity<long>>
    {
        public Webpage(IApplicationLogTools applicationLogTools
                     , IRepository<WebpageContent, long> repository
                     , IMapper mapper) : base(applicationLogTools, repository, mapper)
        {
        }
    }
}
