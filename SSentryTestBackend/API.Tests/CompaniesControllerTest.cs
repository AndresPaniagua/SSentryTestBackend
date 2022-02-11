using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SSentryTestBackend.API.Controllers;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
using SSentryTestBackend.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class CompaniesControllerTest
    {
        [Fact]
        public async Task GetCompaniesCorrect()
        {
            int id = 900674336;
            int count = 1;

            IEnumerable<Company> fakeCompanies = A.CollectionOfDummy<Company>(count).AsEnumerable();
            ICompanyService dataStoreCompany = A.Fake<ICompanyService>();
            IMapper dataStoreMapper = A.Fake<IMapper>();

            IEnumerable<Company> forTesting = new List<Company> { dataStoreCompany.GetCompanyByIdentification(id).Result }.AsEnumerable();

            A.CallTo(() => forTesting).Returns(Task.FromResult(fakeCompanies).Result);

            CompaniesController controller = new(dataStoreCompany, dataStoreMapper);

            // Act
            IActionResult actionResult = await controller.GetCompany(id);

            //Assert
            OkObjectResult result = actionResult as OkObjectResult;
            IEnumerable<Company> returnValue = result.Value as IEnumerable<Company>;

            Assert.Equal(count, returnValue.ToList().Count);
        }
    }
}
