using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BLTS.WebApi.Logs
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationLogController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;

        public ApplicationLogController(IApplicationLogTools applicationLogTools)
        {
            _applicationLogTools = applicationLogTools;
        }


        [HttpPost]
        public void LogError(string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogError(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName } }, callerMemberName);
        }

        [HttpPost]
        public void LogInformation(string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogInformation(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName } }, callerMemberName);
        }

        [HttpPost]
        public void LogWarning(string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogWarning(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName } }, callerMemberName);
        }
    }
}
