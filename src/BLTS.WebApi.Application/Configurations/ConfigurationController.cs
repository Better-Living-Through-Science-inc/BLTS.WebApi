using BLTS.WebApi.DtoModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BLTS.WebApi.Configurations
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private ConfigurationManager _configurationManager;

        public ConfigurationController(ConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Get a value from the config system
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<dynamic> Get(string propertyName, long applicationId)
        {
            return _configurationManager.GetValue(propertyName, applicationId);
        }

        /// <summary>
        /// Set a value in the config system and save to DB optional
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(OperationalConfigurationCreateDto input)
        {
            _configurationManager.SetValue(input.PropertyName, input.PropertyValue, input.IsUpdateDatabase, input.ApplicationId);
        }
    }
}

