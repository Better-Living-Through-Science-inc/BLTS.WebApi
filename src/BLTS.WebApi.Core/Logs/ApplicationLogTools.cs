using BLTS.WebApi.Configurations;
using BLTS.WebApi.Models;
//using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BLTS.WebApi.Logs
{
    /// <summary>
    /// provides easy logging to multiple sources for the system
    /// </summary>
    public class ApplicationLogTools : IApplicationLogTools
    {
        private IRepository<ApplicationLog, long> _repositoryApplicationLog;
        private ConfigurationManager _configurationManager;

        public ApplicationLogTools(ConfigurationManager configurationManager,
                                   IRepository<ApplicationLog, long> repositoryApplicationLog)
        {
            _repositoryApplicationLog = repositoryApplicationLog;
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// logs exceptions
        /// </summary>
        /// <param name="applicationError"></param>
        public void LogError(Exception applicationError, Dictionary<string, dynamic> actionDictionary = null, [CallerMemberName] string callerMemberName = null)
        {
            string logText = applicationError.ToString();
            LogError(logText, actionDictionary, callerMemberName);
        }

        /// <summary>
        /// logs text message as error
        /// </summary>
        /// <param name="logText"></param>
        public void LogError(string logText, Dictionary<string, dynamic> actionDictionary = null, [CallerMemberName] string callerMemberName = null)
        {
            EventLogEntryType currentLogType = EventLogEntryType.Error;
            LogToDatabaseApplicationLog(logText, currentLogType, actionDictionary, callerMemberName);
            LogToAppCenterLog(logText, currentLogType, actionDictionary, callerMemberName);
        }

        /// <summary>
        /// logs text message as warning
        /// </summary>
        /// <param name="logText"></param>
        public void LogWarning(string logText, Dictionary<string, dynamic> actionDictionary = null, [CallerMemberName] string callerMemberName = null)
        {
            EventLogEntryType currentLogType = EventLogEntryType.Warning;
            LogToDatabaseApplicationLog(logText, currentLogType, actionDictionary, callerMemberName);
            LogToAppCenterLog(logText, currentLogType, actionDictionary, callerMemberName);
        }

        /// <summary>
        /// logs text message as information
        /// </summary>
        /// <param name="logText"></param>
        public void LogInformation(string logText, Dictionary<string, dynamic> actionDictionary = null, [CallerMemberName] string callerMemberName = null)
        {
            EventLogEntryType currentLogType = EventLogEntryType.Information;
            LogToDatabaseApplicationLog(logText, currentLogType, actionDictionary, callerMemberName);
            LogToAppCenterLog(logText, currentLogType, actionDictionary, callerMemberName);
        }

        /// <summary>
        /// determin if activation of a type of message is needed
        /// </summary>
        /// <param name="currentLogType"></param>
        /// <param name="activationSetting"></param>
        /// <returns></returns>
        private bool DeterminActivationSetting(EventLogEntryType currentLogType, string activationSetting)
        {
            bool activate = false;
            switch (activationSetting)
            {
                case "Error":
                    if (currentLogType <= EventLogEntryType.Error)
                        activate = true;
                    break;
                case "Warning":
                    if (currentLogType <= EventLogEntryType.Warning)
                        activate = true;
                    break;
                case "Information":
                    if (currentLogType <= EventLogEntryType.Information)
                        activate = true;
                    break;
            }
            return activate;
        }

        /// <summary>
        /// logs data to the database app log
        /// </summary>
        /// <param name="logText"></param>
        /// <param name="currentLogType"></param>
        private void LogToDatabaseApplicationLog(string logText, EventLogEntryType currentLogType, Dictionary<string, dynamic> actionDictionary, string callerMemberName)
        {
            if (DeterminActivationSetting(currentLogType, _configurationManager.GetValue("DatabaseAppLogLevel")))
            {
                ApplicationLog currentLogEntry = new ApplicationLog
                {
                    ApplicationId = actionDictionary.ContainsKey("ApplicationId") ? actionDictionary["ApplicationId"] : _configurationManager.GetCurrentApplicationId(),
                    ApplicationName = $"{_configurationManager.GetValue("ApplicationName")} ver. {_configurationManager.GetValue("ApplicationVersion")}",
                    EnvironmentName = _configurationManager.GetValue("EnvironmentName"),
                    ExecutionTime = DateTime.Now.ToUniversalTime(),
                    ExecutionDuration = -5555
                };

                if (actionDictionary != null)
                {
                    if (actionDictionary.ContainsKey("ApplicationName"))
                        currentLogEntry.ApplicationName = actionDictionary["ApplicationName"];

                    if (actionDictionary.ContainsKey("EnvironmentName"))
                        currentLogEntry.EnvironmentName = actionDictionary["EnvironmentName"];

                    if (actionDictionary.ContainsKey("ExecutionTime"))
                        currentLogEntry.ExecutionTime = actionDictionary["ExecutionTime"];

                    if (actionDictionary.ContainsKey("ExecutionDuration"))
                        currentLogEntry.ExecutionDuration = actionDictionary["ExecutionDuration"];

                    if (actionDictionary.ContainsKey("MethodName"))
                        currentLogEntry.MethodName = actionDictionary["MethodName"];
                    else if (!string.IsNullOrWhiteSpace(callerMemberName))
                        currentLogEntry.MethodName = callerMemberName;

                    if (actionDictionary.ContainsKey("ClassName"))
                        currentLogEntry.ClassName = actionDictionary["ClassName"];
                }

                switch (currentLogType)
                {
                    case EventLogEntryType.Error:
                        {
                            currentLogEntry.Description = $"{_configurationManager.GetValue("ApplicationNameInErrorLog")} - Error Detected";
                            currentLogEntry.ExceptionStacktrace = logText.Length <= 4000 ? logText : logText.Substring(0, 4000);

                            break;
                        }
                    case EventLogEntryType.Warning:
                        {
                            currentLogEntry.Description = logText.Length <= 2000 ? logText : logText.Substring(0, 2000);

                            break;
                        }
                    case EventLogEntryType.Information:
                        {
                            currentLogEntry.Description = logText.Length <= 2000 ? logText : logText.Substring(0, 2000);

                            break;
                        }
                }

                _repositoryApplicationLog.Insert(currentLogEntry);
            }

        }

        /// <summary>
        /// logs data to the AppCenter
        /// </summary>
        /// <param name="logText"></param>
        /// <param name="currentLogType"></param>
        private void LogToAppCenterLog(string logText, EventLogEntryType currentLogType, Dictionary<string, dynamic> actionDictionary, string callerMemberName)
        {
            if (DeterminActivationSetting(currentLogType, _configurationManager.GetValue("AppCenterAppLogLevel")))
            {
                Dictionary<string, string> currentLogEntry = new Dictionary<string, string>();
                currentLogEntry.Add("ApplicationName", $"{_configurationManager.GetValue("ApplicationName")} ver. {_configurationManager.GetValue("ApplicationVersion")}");
                currentLogEntry.Add("EnvironmentName", _configurationManager.GetValue("EnvironmentName"));


                if (actionDictionary != null)
                {
                    if (actionDictionary.ContainsKey("ExecutionDuration"))
                        currentLogEntry.Add("ExecutionDuration", $"{actionDictionary["ExecutionDuration"]}");
                    if (actionDictionary.ContainsKey("MethodName") && actionDictionary.ContainsKey("ClassName"))
                        currentLogEntry.Add("MethodName", $"{actionDictionary["ClassName"]}.{actionDictionary["MethodName"]}");
                    else if (!string.IsNullOrWhiteSpace(callerMemberName) && actionDictionary.ContainsKey("ClassName"))
                        currentLogEntry.Add("MethodName", $"{actionDictionary["ClassName"]}.{callerMemberName}");
                    else
                    {
                        if (actionDictionary.ContainsKey("MethodName"))
                            currentLogEntry.Add("MethodName", actionDictionary["MethodName"]);
                        else if (!string.IsNullOrWhiteSpace(callerMemberName))
                            currentLogEntry.Add("MethodName", callerMemberName);

                        if (actionDictionary.ContainsKey("ClassName"))
                            currentLogEntry.Add("ClassName", actionDictionary["ClassName"]);
                    }
                }

                //if (currentLogEntry.ContainsKey("MethodName"))
                //    logText = _configurationManager.GetValue("EnvironmentName") + " " + currentLogEntry["MethodName"] + ": " + logText;

                currentLogEntry.Add("CustomData", logText);

                //Analytics.TrackEvent(currentLogType.ToString(), currentLogEntry);
            }

        }
    }
}
