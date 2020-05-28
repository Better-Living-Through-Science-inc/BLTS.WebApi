using System.Threading.Tasks;
using BLTS.Web.Models.TokenAuth;
using BLTS.Web.Web.Controllers;
using Shouldly;
using Xunit;

namespace BLTS.Web.Web.Tests.Controllers
{
    public class HomeController_Tests: WebWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}