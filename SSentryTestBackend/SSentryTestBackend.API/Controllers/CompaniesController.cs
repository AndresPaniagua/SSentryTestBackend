using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSentryTestBackend.API.Responses;
using SSentryTestBackend.Core.DTOs;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Interfaces.Services;
using System.Net;
using System.Threading.Tasks;

namespace SSentryTestBackend.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve company information by identification number
        /// </summary>
        /// <param name="id">It's the company identification number</param>
        /// <returns>Object with company data</returns>
        [HttpGet("{id}")]
        [HttpGet(Name = nameof(GetCompany))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Company))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Company))]
        public async Task<IActionResult> GetCompany(int id)
        {
            return Ok(await _companyService.GetCompanyByIdentification(id));
        }

        /// <summary>
        /// Update company information 
        /// </summary>
        /// <param name="id">It's the company identity number in the database </param>
        /// <param name="entity">It's the company aditional information to update</param>
        /// <returns>True or false</returns>
        [HttpPut("{id}")]
        [HttpPut(Name = nameof(Put))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<bool>))]
        public async Task<IActionResult> Put(int id, CompanyDto entity)
        {
            bool result = await _companyService.UpdateCompany(_mapper.Map<Company>(entity));
            ApiResponse<bool> response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
