using Microsoft.AspNetCore.Mvc;
using CognitusBackend.Infrastructure.Data;
using CognitusBackend.Application.Services;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Application.UseCase.Auth;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class AuthController : ControllerBase
    {
        private readonly Context _context;
        private readonly TokenService _tokenService;

        public AuthController(Context context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Authenticate([FromBody] User user)
        {
            var UseCase = new RegisterUseCase(_context, _tokenService);

            var responseRegister = await UseCase.registerExecute(user);

            return Created("", responseRegister.Value);
        }
    }
}
