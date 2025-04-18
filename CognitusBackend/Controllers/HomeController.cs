using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using CognitusBackend.Application.UseCase.Home;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class HomeController : ControllerBase
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }


        [Authorize]
        [HttpGet]
        [Route("home")]
        public async Task<ActionResult> Home()
        {
            var useCase = new HomeUseCase(_context);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var guidId = Guid.Parse(userId);

            var result = await useCase.executeHome(guidId);

            return Ok(result.Value);
        }

    }
}
