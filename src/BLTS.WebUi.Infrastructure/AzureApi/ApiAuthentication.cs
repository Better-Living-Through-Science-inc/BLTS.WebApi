using BLTS.WebApi.Configurations;
using BLTS.WebApi.Infrastructure.AzureApi.Models;
using BLTS.WebApi.Logs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BLTS.WebApi.Infrastructure.AzureApi
{
    public class ApiAuthentication
    {
        private readonly IApplicationLogTools _applicationLogTools;
        private readonly ConfigurationManager _configurationManager;
        private readonly HttpClient _httpClient;

        public ApiAuthentication(ConfigurationManager configurationManager
                               , IApplicationLogTools applicationLogTools
                               , HttpClient httpClient)
        {
            _applicationLogTools = applicationLogTools;
            _configurationManager = configurationManager;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Tests current login creds for validity
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ApiTestLoginAsync()
        {
            try
            {
                if (_httpClient.BaseAddress == null)
                    _httpClient.BaseAddress = new Uri(_configurationManager.GetValue("ApiBaseAddress"));
                return await ExecuteLoginAsync(_httpClient);
            }
            catch (Exception authenticationError)
            {
                _applicationLogTools.LogError(authenticationError, new Dictionary<string, dynamic> { { "MethodName", "ApiTestLoginAsync" }, { "ClassName", "AzureApi.ApiAuthentication" } });
            }

            return false;
        }

        /// <summary>
        /// login to the API
        /// </summary>
        /// <param name="currentApiHttpClient"></param>
        /// <returns></returns>
        internal async Task<bool> ExecuteLoginAsync(HttpClient currentApiHttpClient)
        {
            try
            {
                string subPathUri = _configurationManager.GetValue("ApiAuthenticationPath");

                AuthenticationLogin authenticationLoginObject = new AuthenticationLogin
                {
                    UsernameOrEmailAddress = _configurationManager.GetValue("UserName"),
                    Password = _configurationManager.GetValue("UserPassword"),
                    RememberMe = true
                };

                if (string.IsNullOrWhiteSpace(authenticationLoginObject.UsernameOrEmailAddress)
                    || string.IsNullOrWhiteSpace(authenticationLoginObject.Password))
                    return false;

                HttpResponseMessage authResponseResult = currentApiHttpClient.PostAsJsonAsync(subPathUri, authenticationLoginObject).Result;
                authResponseResult.EnsureSuccessStatusCode();

                AuthenticationResponse loginResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(await authResponseResult.Content.ReadAsStringAsync());
                if (loginResponse.Result == 1)
                    return true;
            }
            catch (Exception authenticationError)
            {
                _applicationLogTools.LogError(authenticationError, new Dictionary<string, dynamic> { { "ClassName", "AzureApi.ApiAuthentication" } });
            }

            return false;
        }
    }
}
