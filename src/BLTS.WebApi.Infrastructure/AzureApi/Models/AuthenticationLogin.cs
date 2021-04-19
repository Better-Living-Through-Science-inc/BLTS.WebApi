namespace BLTS.WebApi.Infrastructure.AzureApi.Models
{
    class AuthenticationLogin
    {
        public string UsernameOrEmailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
