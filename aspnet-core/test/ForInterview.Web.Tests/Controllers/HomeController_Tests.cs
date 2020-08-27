using System.Threading.Tasks;
using ForInterview.Models.TokenAuth;
using ForInterview.Web.Controllers;
using Shouldly;
using Xunit;

namespace ForInterview.Web.Tests.Controllers
{
    public class HomeController_Tests: ForInterviewWebTestBase
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