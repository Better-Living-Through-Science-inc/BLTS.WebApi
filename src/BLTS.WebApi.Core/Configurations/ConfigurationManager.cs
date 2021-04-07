using BLTS.WebApi.Models;
using BLTS.WebApi.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Caching;

namespace BLTS.WebApi.Configurations
{
    /// <summary>
    /// provides easy access to set and retrieve application level variables 
    /// </summary>
    public class ConfigurationManager
    {
        private IConfiguration _configuration;
        private IRepository<Application, long> _repositoryApplication;
        private IRepository<OperationalConfiguration, long> _repositoryOperationalConfiguration;
        private long _currentApplicationId;

        public ConfigurationManager(IConfiguration configuration
                                  , IRepository<Application, long> repositoryApplication
                                  , IRepository<OperationalConfiguration, long> repositoryOperationalConfiguration)
        {
            _configuration = configuration;
            _repositoryOperationalConfiguration = repositoryOperationalConfiguration;
            _repositoryApplication = repositoryApplication;
            _currentApplicationId = long.Parse(_configuration.GetSection("App")["ApplicationId"].ToString());
            // preload the config data on startup
            VerifyConfigDataLoaded();
        }

        /// <summary>
        /// cache access method
        /// </summary>
        /// <returns></returns>
        private ConcurrentDictionary<long, ConcurrentDictionary<string, dynamic>> VerifyConfigDataLoaded()
        {
            MemoryCache memoryCache = MemoryCache.Default;

            return memoryCache.AddOrGetExistingCacheEntry(nameof(ConfigurationManager) + nameof(VerifyConfigDataLoaded),
                                                          GenerateCurrentConfigSettings,
                                                          new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddHours(1) });
        }

        /// <summary>
        /// Load config from DB replacementknownPropertiesDictionary knownProperties
        /// </summary>
        /// <returns>Dictionary in the form of AppId, Config Property, Config Value</returns>
        private ConcurrentDictionary<long, ConcurrentDictionary<string, dynamic>> GenerateCurrentConfigSettings()
        {
            ConcurrentDictionary<long, ConcurrentDictionary<string, dynamic>> applicationVariableDictionary = new ConcurrentDictionary<long, ConcurrentDictionary<string, dynamic>>();

            #region begin extract of primary app vars from config files
            //add current app id to the dictionary
            applicationVariableDictionary.TryAdd(_currentApplicationId, new ConcurrentDictionary<string, dynamic>());
            _configuration.AsEnumerable().AsParallel()
                          .Where(singleConfigurationValue => singleConfigurationValue.Key.Contains("ConnectionStrings", StringComparison.InvariantCultureIgnoreCase) == false
                                                          && !string.IsNullOrWhiteSpace(singleConfigurationValue.Value))
                          .ForAll(singleConfigurationValue => applicationVariableDictionary[_currentApplicationId].TryAdd(singleConfigurationValue.Key.Replace("Values:", "").Replace("App:", ""), singleConfigurationValue.Value));
            #endregion

            #region begin extract of connection strings in the config data
            applicationVariableDictionary[_currentApplicationId].TryAdd("ConnectionStrings", new ConcurrentDictionary<string, string>());
            _configuration.AsEnumerable().AsParallel()
                          .Where(singleConfigurationValue => singleConfigurationValue.Key.Contains("ConnectionStrings:", StringComparison.InvariantCultureIgnoreCase) == true
                                                          && !string.IsNullOrWhiteSpace(singleConfigurationValue.Value))
                          .ForAll(singleConfigurationValue => applicationVariableDictionary[_currentApplicationId]["ConnectionStrings"].TryAdd(singleConfigurationValue.Key.Replace("ConnectionStrings:", ""), singleConfigurationValue.Value));
            #endregion

            #region load config data from DB storage

            //load application values
            List<Application> applicationCollection = _repositoryApplication.GetAll().ItemCollection;

            applicationCollection.AsParallel()
                                 .ForAll(singleAppValue =>
                                 {
                                     applicationVariableDictionary.TryAdd(singleAppValue.Id, new ConcurrentDictionary<string, dynamic>());
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationName", singleAppValue.Name);
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationVersion", singleAppValue.Version);
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationTitle", singleAppValue.Title);
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationDescription", singleAppValue.Description);
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationPocEmail", singleAppValue.PocEmail);
                                     applicationVariableDictionary[singleAppValue.Id].TryAdd("ApplicationPocNumber", singleAppValue.PocNumber);
                                 });


            //load configuration values
            List<OperationalConfiguration> configurationColletion = _repositoryOperationalConfiguration.GetAll().ItemCollection;

            configurationColletion.AsParallel()
                                  .Where(singleConfigurationValue => singleConfigurationValue.IsConnectionString == false)
                                  .ForAll(singleConfigurationValue => applicationVariableDictionary[singleConfigurationValue.ApplicationId].TryAdd(singleConfigurationValue.PropertyName,
                                                                                                                                                  (singleConfigurationValue.IntegerValue.HasValue) ? singleConfigurationValue.IntegerValue :
                                                                                                                                                  (singleConfigurationValue.StringValue != null) ? singleConfigurationValue.StringValue :
                                                                                                                                                  (singleConfigurationValue.BoolValue.HasValue) ? singleConfigurationValue.BoolValue :
                                                                                                                                                  (singleConfigurationValue.DateValue.HasValue) ? singleConfigurationValue.DateValue :
                                                                                                                                                  (singleConfigurationValue.LongValue.HasValue) ? singleConfigurationValue.LongValue :
                                                                                                                                                  (singleConfigurationValue.DecimalValue.HasValue) ? singleConfigurationValue.DecimalValue :
                                                                                                                                                  (singleConfigurationValue.GuidValue.HasValue) ? singleConfigurationValue.GuidValue : (dynamic)"No Value Assigned"
                                                                                                                                                  ));


            configurationColletion.AsParallel()
                                  .Where(singleConfigurationValue => singleConfigurationValue.IsConnectionString == true)
                                  .ForAll(singleConfigurationValue => applicationVariableDictionary[singleConfigurationValue.ApplicationId]["ConnectionStrings"].TryAdd(singleConfigurationValue.PropertyName, singleConfigurationValue.StringValue));

            configurationColletion = null;
            #endregion

            #region assign config data from application and environment data
            applicationVariableDictionary[_currentApplicationId].TryAdd("ProcessorCount", Environment.ProcessorCount);
            applicationVariableDictionary[_currentApplicationId].TryAdd("EnvironmentName", Environment.MachineName);
            applicationVariableDictionary[_currentApplicationId].TryAdd("EnvironmentType", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

            if (!applicationVariableDictionary[_currentApplicationId].ContainsKey("ApplicationName"))
            {
                string applicationName = Environment.GetEnvironmentVariable("ApplicationName");

                if (string.IsNullOrWhiteSpace(applicationName))
                    applicationName = Process.GetCurrentProcess().ProcessName;

                if (string.IsNullOrWhiteSpace(applicationName))
                    applicationName = "ApplicationNameUnknown";

                applicationVariableDictionary[_currentApplicationId].TryAdd("ApplicationName", applicationName);
            }
            applicationVariableDictionary[_currentApplicationId].AddOrUpdate("ApplicationNameInErrorLog", applicationVariableDictionary[_currentApplicationId]["ApplicationName"], (Func<string, dynamic, dynamic>)((key, existingValue) => applicationVariableDictionary[_currentApplicationId]["ApplicationName"]));
            #endregion

            return applicationVariableDictionary;
        }

        /// <summary>
        /// returns the app id of the current instance of the app
        /// </summary>
        /// <returns></returns>
        public long GetCurrentApplicationId()
        {
            return _currentApplicationId;
        }

        /// <summary>
        /// returns the full config dictionary
        /// </summary>
        /// <returns>Dictionary in the form of Config Property, Config Value</returns>
        public ConcurrentDictionary<string, dynamic> GetAll(long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            return VerifyConfigDataLoaded()[applicationId.Value];
        }

        /// <summary>
        /// returns the requested setting value or null
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <returns></returns>
        public dynamic GetValue(string requestedConfigurationName, long? applicationId = null)
        {
            dynamic currentReturnObject = null;

            applicationId ??= _currentApplicationId;

            if (VerifyConfigDataLoaded()[applicationId.Value].ContainsKey(requestedConfigurationName))
                currentReturnObject = VerifyConfigDataLoaded()[applicationId.Value][requestedConfigurationName];

            return currentReturnObject;
        }

        /// <summary>
        /// returns the requested setting value or null
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <returns></returns>
        public string GetConnectionString(string requestedConnectionStringName, long? applicationId = null)
        {
            string currentReturnObject = null;
            applicationId ??= _currentApplicationId;
            if (VerifyConfigDataLoaded()[applicationId.Value]["ConnectionStrings"].ContainsKey(requestedConnectionStringName))
                currentReturnObject = (string)VerifyConfigDataLoaded()[applicationId.Value]["ConnectionStrings"][requestedConnectionStringName];

            return currentReturnObject;
        }

        /// <summary>
        /// used to update existing values if they need to change during runtime via  value
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <param name="newAssignmentValue"></param>
        public void SetValue(string requestedConfigurationName, dynamic newAssignmentValue, bool isUpdateDatabase = false, long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            VerifyConfigDataLoaded()[applicationId.Value].AddOrUpdate(requestedConfigurationName, newAssignmentValue, (Func<string, dynamic, dynamic>)((key, existingValue) => newAssignmentValue));

            if (isUpdateDatabase == true)
            {

                OperationalConfiguration currentWorkingObject = _repositoryOperationalConfiguration.GetAll().ItemCollection.Where(singleConfig => singleConfig.PropertyName == requestedConfigurationName).FirstOrDefault();

                if (currentWorkingObject == null)
                {
                    currentWorkingObject = new OperationalConfiguration();
                    currentWorkingObject.PropertyName = requestedConfigurationName;
                    currentWorkingObject.Description = requestedConfigurationName;
                    currentWorkingObject.IsEnabled = true;
                    currentWorkingObject.IsConnectionString = false;

                    _repositoryOperationalConfiguration.Insert(currentWorkingObject);
                }

                AssignValueToCorrectProperty(newAssignmentValue, currentWorkingObject);

                _repositoryOperationalConfiguration.Update(currentWorkingObject);
            }
        }

        /// <summary>
        /// used to update existing values if they need to change during runtime via funct call (value returned)
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <param name="valueFactory"></param>
        public dynamic SetValue<T>(string requestedConfigurationName, Func<T> valueFactory, bool isUpdateDatabase = false, long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            VerifyConfigDataLoaded()[applicationId.Value].AddOrUpdate(requestedConfigurationName, valueFactory.Invoke(), (Func<string, dynamic, dynamic>)((key, existingValue) => valueFactory.Invoke()));

            if (isUpdateDatabase == true)
            {
                OperationalConfiguration currentWorkingObject = _repositoryOperationalConfiguration.GetAll().ItemCollection.Where(singleConfig => singleConfig.PropertyName == requestedConfigurationName).FirstOrDefault();

                if (currentWorkingObject == null)
                {
                    currentWorkingObject = new OperationalConfiguration();
                    currentWorkingObject.PropertyName = requestedConfigurationName;
                    currentWorkingObject.Description = requestedConfigurationName;
                    currentWorkingObject.IsEnabled = true;
                    currentWorkingObject.IsConnectionString = false;

                    _repositoryOperationalConfiguration.Insert(currentWorkingObject);
                }

                AssignValueToCorrectProperty(GetValue(requestedConfigurationName), currentWorkingObject);

                _repositoryOperationalConfiguration.Update(currentWorkingObject);

            }

            return VerifyConfigDataLoaded()[applicationId.Value][requestedConfigurationName];
        }

        /// <summary>
        /// used to insert new values if they do not yet exist via funct call (existing or new value returned)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestedConfigurationName"></param>
        /// <param name="valueFactory"></param>
        /// <param name="isUpdateDatabase"></param>
        /// <returns></returns>
        public dynamic SetOrGetValue<T>(string requestedConfigurationName, Func<T> valueFactory, bool isUpdateDatabase = false, long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            if (VerifyConfigDataLoaded()[applicationId.Value].ContainsKey(requestedConfigurationName))
                return VerifyConfigDataLoaded()[applicationId.Value][requestedConfigurationName];
            else
                return SetValue<T>(requestedConfigurationName, valueFactory, isUpdateDatabase);
        }

        /// <summary>
        /// used to update existing values if they need to change during runtime
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <param name="newAssignmentValue"></param>
        public void SetConnectionString(string requestedConfigurationName, string newAssignmentValue, bool isUpdateDatabase = false, long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            VerifyConfigDataLoaded()[applicationId.Value]["ConnectionStrings"].AddOrUpdate(requestedConfigurationName, newAssignmentValue, (Func<string, dynamic, dynamic>)((key, existingValue) => newAssignmentValue));
            if (isUpdateDatabase == true)
            {
                OperationalConfiguration currentWorkingObject = _repositoryOperationalConfiguration.GetAll().ItemCollection.Where(singleConfig => singleConfig.PropertyName == requestedConfigurationName).FirstOrDefault();

                if (currentWorkingObject == null)
                {
                    currentWorkingObject = new OperationalConfiguration();
                    currentWorkingObject.PropertyName = requestedConfigurationName;
                    currentWorkingObject.Description = requestedConfigurationName;
                    currentWorkingObject.IsEnabled = true;
                    currentWorkingObject.IsConnectionString = true;

                    _repositoryOperationalConfiguration.Insert(currentWorkingObject);
                }
                currentWorkingObject.StringValue = newAssignmentValue;

                _repositoryOperationalConfiguration.Update(currentWorkingObject);
            }
        }

        /// <summary>
        /// deletes the requested setting value
        /// </summary>
        /// <param name="requestedConfigurationName"></param>
        /// <returns></returns>
        public void DeleteValue(string requestedConfigurationName, bool isUpdateDatabase = false, long? applicationId = null)
        {
            applicationId ??= _currentApplicationId;
            if (VerifyConfigDataLoaded()[applicationId.Value].ContainsKey(requestedConfigurationName))
                VerifyConfigDataLoaded()[applicationId.Value].TryRemove(requestedConfigurationName, out _);

            if (isUpdateDatabase == true)
            {
                OperationalConfiguration currentWorkingObject = _repositoryOperationalConfiguration.GetAll().ItemCollection.Where(singleConfig => singleConfig.PropertyName == requestedConfigurationName).FirstOrDefault();
                if (currentWorkingObject != null)
                {
                    _repositoryOperationalConfiguration.Delete(currentWorkingObject);
                }

            }
        }

        /// <summary>
        /// assign the value to the correct property based on its data type
        /// </summary>
        /// <param name="newAssignmentValue"></param>
        /// <param name="currentWorkingObject"></param>
        private void AssignValueToCorrectProperty(dynamic newAssignmentValue, OperationalConfiguration currentWorkingObject)
        {
            currentWorkingObject.BoolValue = null;
            currentWorkingObject.DateValue = null;
            currentWorkingObject.DecimalValue = null;
            currentWorkingObject.GuidValue = null;
            currentWorkingObject.IntegerValue = null;
            currentWorkingObject.LongValue = null;
            currentWorkingObject.StringValue = null;


            switch (Type.GetTypeCode(newAssignmentValue.GetType()))
            {
                case TypeCode.Boolean:
                    {
                        currentWorkingObject.BoolValue = Convert.ChangeType(newAssignmentValue, typeof(bool));
                        break;
                    }

                case TypeCode.DateTime:
                    {
                        currentWorkingObject.DateValue = Convert.ChangeType(newAssignmentValue, typeof(DateTime));
                        break;
                    }

                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    {
                        currentWorkingObject.DecimalValue = Convert.ChangeType(newAssignmentValue, typeof(decimal));
                        break;
                    }

                case TypeCode.Object:
                    {
                        if (newAssignmentValue.GetType() == typeof(Guid))
                            currentWorkingObject.GuidValue = Convert.ChangeType(newAssignmentValue, typeof(Guid));
                        break;
                    }

                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                    {
                        currentWorkingObject.IntegerValue = Convert.ChangeType(newAssignmentValue, typeof(int));
                        break;
                    }

                case TypeCode.Int64:
                case TypeCode.UInt64:
                    {
                        currentWorkingObject.LongValue = Convert.ChangeType(newAssignmentValue, typeof(long));
                        break;
                    }


                case TypeCode.String:
                case TypeCode.Char:
                default:
                    {
                        currentWorkingObject.StringValue = Convert.ChangeType(newAssignmentValue, typeof(string), new CultureInfo("en-US"));
                        break;
                    }
            }
        }

    }
}
