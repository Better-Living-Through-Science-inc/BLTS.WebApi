using BLTS.WebApi.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BLTS.WebApi.Configurations
{
    //[Produces("application/json")]
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    //public class ConfigurationController : ControllerBase, IApiEndpoint
    //{
    //    private ConfigurationManager _configurationManager;

    //    public ConfigurationController(ConfigurationManager configurationManager)
    //    {
    //        _configurationManager = configurationManager;
    //    }

    //    /// <summary>
    //    /// Get a value from the config system
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    [HttpGet]
    //    public dynamic Get(OperationalConfigurationDto input)
    //    {
    //        return _configurationManager.GetValue(input.PropertyName);
    //    }

    //    /// <summary>
    //    /// Set a value in the config system and save to DB optional
    //    /// </summary>
    //    /// <param name="input"></param>
    //    /// <returns></returns>
    //    [HttpPost]
    //    public void Save(OperationalConfigurationCreateDto input)
    //    {
    //        _configurationManager.SetValue(input.PropertyName, input.PropertyValue, input.IsUpdateDatabase);
    //    }
    //}
}

