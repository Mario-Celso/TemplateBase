using Application.UseCases;
using Application.UseCases.Interfaces;
using Domain.Models.In;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUsersUseCases _usersUseCase;

        public UserController(ILogger<UserController> logger, IUsersUseCases usersUseCase)
        {
            _logger = logger;
            _usersUseCase = usersUseCase;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var authResult = _usersUseCase.Register(userRegisterRequest);
            return Ok(authResult);
        }
    }
}