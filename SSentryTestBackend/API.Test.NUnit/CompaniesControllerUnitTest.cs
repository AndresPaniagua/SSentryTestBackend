using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SSentryTestBackend.API.Controllers;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
using System.Threading.Tasks;

namespace API.Test.NUnit
{
    public class CompaniesControllerUnitTest
    {
        [Test]
        public async Task GetCompaniesCorrect()
        {
            int id = 900674336;

            ICompanyService dataStoreCompany = A.Fake<ICompanyService>();
            IMapper dataStoreMapper = A.Fake<IMapper>();

            CompaniesController controller = new CompaniesController(dataStoreCompany, dataStoreMapper);

            // Act
            IActionResult actionResult = await controller.GetCompany(id);

            //Assert
            OkObjectResult result = actionResult as OkObjectResult;

            Assert.IsInstanceOf<Company>(result.Value);
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
        }
    }
}
