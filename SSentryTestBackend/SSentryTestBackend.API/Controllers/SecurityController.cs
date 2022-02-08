using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSentryTestBackend.API.Responses;
using SSentryTestBackend.Core.DTOs;
using SSentryTestBackend.Core.Entities;
using SSentryTestBackend.Core.Enumerations;
using SSentryTestBackend.Core.Interfaces.Services;
using SSentryTestBackend.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace SSentryTestBackend.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Security(SecurityDto entity)
        {
            var security = _mapper.Map<Security>(entity);
            security.Password = _passwordService.Hash(security.Password);
            await _securityService.RegisterUser(security);
            entity = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(entity);
            return Ok(response);
        }
    }
}
