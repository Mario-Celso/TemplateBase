using Application.UseCases.Interfaces;
using Domain.Models.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthUseCases _authUseCase;

        public AuthController(ILogger<AuthController> logger, IAuthUseCases authUseCase)
        {
            _logger = logger;
            _authUseCase = authUseCase;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
        {
            var authResult = _authUseCase.Authenticate(authenticationRequest.UserName, authenticationRequest.Password);
            
            if (authResult == null)
                return Unauthorized();
            else
                return Ok(authResult);
        }
    }
}