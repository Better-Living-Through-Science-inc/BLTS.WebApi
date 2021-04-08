using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BLTS.WebApi.Logs
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ApplicationLogController : ControllerBase
    {
        private readonly IApplicationLogTools _applicationLogTools;

        public ApplicationLogController(IApplicationLogTools applicationLogTools)
        {
            _applicationLogTools = applicationLogTools;
        }


        [HttpPost]
        public async void LogError(long applicationId, string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogError(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName }, { "ApplicationId", applicationId } }, callerMemberName);
        }

        [HttpPost]
        public async void LogInformation(long applicationId, string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogInformation(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName }, { "ApplicationId" , applicationId } }, callerMemberName);
        }

        [HttpPost]
        public async void LogWarning(long applicationId, string logText, string callerClassName = null, string callerMemberName = null)
        {
            _applicationLogTools.LogWarning(logText, new Dictionary<string, dynamic> { { "ClassName", callerClassName }, { "ApplicationId", applicationId } }, callerMemberName);
        }
    }
}
