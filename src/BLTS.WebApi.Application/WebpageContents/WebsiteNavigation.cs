using AutoMapper;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.Websites
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Webpage : ApiController<WebpageContent, WebpageContentDtoEntity, long, DeleteDtoEntity<long>>
    {
        public Webpage(IRepository<WebpageContent, long> repository
                                 , IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
