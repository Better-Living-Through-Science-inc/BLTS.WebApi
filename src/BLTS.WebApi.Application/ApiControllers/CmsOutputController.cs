using AutoMapper;
using BLTS.WebApi.CmsOutput;
using BLTS.WebApi.DtoModels;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLTS.WebApi.ApiControllers
{
    /// <summary>
    /// Api access to website menus
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CmsOutputController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly IMapper _mapper;
        private readonly CmsOutputManager _cmsOutputManager;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="cmsOutputManager"></param>
        /// <param name="mapper"></param>
        public CmsOutputController(IApplicationLogTools applicationLogTools
                                 , CmsOutputManager cmsOutputManager
                                 , IMapper mapper)
        {
            _applicationLogTools = applicationLogTools;
            _cmsOutputManager = cmsOutputManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets basic website information
        /// </summary>
        /// <param name="websiteBaseUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CmsWebsiteInfoDtoEntity>>> GetWebsiteInformation(string websiteBaseUrl)
        {
            try
            {
                WebsiteInfo currentWebsiteInfo = _cmsOutputManager.GetWebsiteInformation(websiteBaseUrl, User);

                if (currentWebsiteInfo != null)
                    return Ok(MapToDtoEntity(currentWebsiteInfo));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.CmsOutputController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        /// <summary>
        /// Gets Nav Menu for a website based on User permissions
        /// </summary>
        /// <param name="websiteBaseUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CmsNavigationMenuDtoEntity>>> GetWebsiteNavigationMenu(string websiteBaseUrl)
        {
            try
            {
                List<NavigationMenu> currentNavigationMenuCollection = _cmsOutputManager.GetWebsiteNavigationMenu(websiteBaseUrl, User);

                if (currentNavigationMenuCollection.Count > 0)
                    return Ok(MapToDtoEntityCollection(currentNavigationMenuCollection));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.CmsOutputController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        internal virtual CmsWebsiteInfoDtoEntity MapToDtoEntity(WebsiteInfo internalEntity)
        {
            try
            {
                return _mapper.Map<CmsWebsiteInfoDtoEntity>(internalEntity);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.WebsiteNavigationMenuController" } });
                throw;
            }
        }

        internal virtual List<CmsNavigationMenuDtoEntity> MapToDtoEntityCollection(List<NavigationMenu> internalEntityCollection)
        {
            try
            {
                return _mapper.Map<List<CmsNavigationMenuDtoEntity>>(internalEntityCollection);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.WebsiteNavigationMenuController" } });
                throw;
            }
        }

    }
}
