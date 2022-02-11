using SSentryTestBackend.API.Controllers;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
using SSentryTestBackend.Infrastructure.Interfaces;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace API.Test.NUnit
{
    public class TokenControllerUnitTest
    {
        [Test]
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

            TokenController controller = new TokenController(dataStoreConfig, dataStoreSecurity, dataStorePass);

            // Act
            IActionResult actionResult = await controller.Authentication(user);

            // Assert
            OkObjectResult result = actionResult as OkObjectResult;

            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
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

            TokenController controller = new TokenController(dataStoreConfig, dataStoreSecurity, dataStorePass);

            // Act
            IActionResult actionResult = await controller.Authentication(user);

            // Assert
            NotFoundResult result = actionResult as NotFoundResult;

            Assert.IsInstanceOf<NotFoundResult>(actionResult);
            Assert.NotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }

    }
}
