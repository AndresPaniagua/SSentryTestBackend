using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SSentryTestBackend.API.Controllers;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
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
            int id = 1;
            int count = 7;

            IEnumerable<Company> fakeCompanies = A.CollectionOfDummy<Company>(count).AsEnumerable();
            ICompanyService dataStoreCompany = A.Fake<ICompanyService>();
            IMapper dataStoreMapper = A.Fake<IMapper>();
            var forTesting = new List<Company> { dataStoreCompany.GetCompanyByIdentification(id).Result }.AsEnumerable();

            A.CallTo(() => forTesting).Returns<IEnumerable<Company>>(Task.FromResult(fakeCompanies).Result);

            CompaniesController controller = new CompaniesController(dataStoreCompany, dataStoreMapper);

            // Act
            var actionResult = await controller.GetCompany(id);

            //Assert
            var result = actionResult as OkObjectResult;
            var returnValue = result.Value as IEnumerable<Company>;

            Assert.Equal(count, returnValue.ToList().Count);
        }
    }
}
