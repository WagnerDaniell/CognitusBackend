using Microsoft.AspNetCore.Mvc;
using CognitusBackend.Infrastructure.Data;
using CognitusBackend.Application.Services;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Application.UseCase.Auth;
using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Domain.Repositories;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthController(IUserRepository userRepository, TokenService token)
        {
            _userRepository = userRepository;
            _tokenService = token;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Authenticate([FromBody] RegisterRequest user)
        {
            var UseCase = new RegisterUseCase(_tokenService, _userRepository);

            var responseRegister = await UseCase.registerExecute(user);

            return Created("", responseRegister.Value);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest login)
        {
            var UseCase = new LoginUseCase(_tokenService, _userRepository);
            var responseLogin = await UseCase.executeLogin(login);
            return Ok(responseLogin.Value);
        }
    }
}
