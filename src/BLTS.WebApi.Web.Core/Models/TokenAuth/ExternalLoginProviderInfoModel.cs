using Abp.AutoMapper;
using BLTS.WebApi.Authentication.External;

namespace BLTS.WebApi.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
