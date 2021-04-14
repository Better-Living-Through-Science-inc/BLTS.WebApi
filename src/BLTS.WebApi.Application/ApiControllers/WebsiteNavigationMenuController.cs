using AutoMapper;
using BLTS.WebApi.Logs;
using BLTS.WebApi.Models;
using BLTS.WebApi.WebsiteNavigations;
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
    public class WebsiteNavigationMenuController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly IMapper _mapper;
        private readonly WebsiteNavigationMenuManager _websiteNavigationMenuManager;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="applicationLogTools"></param>
        /// <param name="websiteNavigationMenuManager"></param>
        /// <param name="mapper"></param>
        public WebsiteNavigationMenuController(IApplicationLogTools applicationLogTools
                                             , WebsiteNavigationMenuManager websiteNavigationMenuManager
                                             , IMapper mapper)
        {
            _applicationLogTools = applicationLogTools;
            _websiteNavigationMenuManager = websiteNavigationMenuManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets Nav Menu for a website based on User permissions
        /// </summary>
        /// <param name="websiteBaseUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<WebsiteNavigationMenuDtoEntity>>> GetWebsiteNavigationMenu(string websiteBaseUrl)
        {
            try
            {
                List<NavigationMenu> currentNavigationMenyCollection = _websiteNavigationMenuManager.GetWebsiteNavigationMenu(websiteBaseUrl, User);

                if (currentNavigationMenyCollection.Count > 0)
                    return Ok(MapToDtoEntityCollection(currentNavigationMenyCollection));
                else
                    return NotFound();
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.WebsiteNavigationMenuController" } });

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development", StringComparison.InvariantCultureIgnoreCase))
                    return base.StatusCode(500, apiControllerError);
                else
                    return base.StatusCode(500);
            }
        }

        internal virtual List<WebsiteNavigationMenuDtoEntity> MapToDtoEntityCollection(List<NavigationMenu> internalEntityCollection)
        {
            try
            {
                return _mapper.Map<List<WebsiteNavigationMenuDtoEntity>>(internalEntityCollection);
            }
            catch (Exception apiControllerError)
            {
                _applicationLogTools.LogError(apiControllerError, new Dictionary<string, dynamic> { { "ClassName", $"ApiControllers.WebsiteNavigationMenuController" } });
                throw;
            }
        }

    }
}
