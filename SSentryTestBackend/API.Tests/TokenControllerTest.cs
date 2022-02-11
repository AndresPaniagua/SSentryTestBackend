using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SSentryTestBackend.API.Controllers;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
using SSentryTestBackend.Infrastructure.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class TokenControllerTest
    {
        [Fact]
        public async Task GetTokenWithUserCorrect()
        {
            // Arrange
            UserLogin user = new UserLogin
            {
                User = "User",
                Password = "Test"
            };

            IConfiguration dataStoreConfig = A.Fake<IConfiguration>();
            ISecurityService dataStoreSecurity = A.Fake<ISecurityService>();
            IPasswordService dataStorePass = A.Fake<IPasswordService>();

            //IEnumerable<Company> forTesting = new List<Company> { dataStoreCompany.GetCompanyByIdentification(id).Result }.AsEnumerable();

            //A.CallTo(() => forTesting).Returns(Task.FromResult(fakeCompanies).Result);

            TokenController controller = new(dataStoreConfig, dataStoreSecurity, dataStorePass);

            // Act
            IActionResult actionResult = await controller.Authentication(user);

            // Assert
            OkObjectResult result = actionResult as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetTokenWithUserIncorrect()
        {
            // Arrange
            UserLogin user = new UserLogin
            {
                User = "cualquiera",
                Password = "1234"
            };

            IConfiguration dataStoreConfig = A.Fake<IConfiguration>();
            ISecurityService dataStoreSecurity = A.Fake<ISecurityService>();
            IPasswordService dataStorePass = A.Fake<IPasswordService>();

            TokenController controller = new(dataStoreConfig, dataStoreSecurity, dataStorePass);

            // Act
            IActionResult actionResult = await controller.Authentication(user);

            // Assert
            NotFoundResult result = actionResult as NotFoundResult;

            Assert.IsType<NotFoundResult>(actionResult);
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

    }
}
