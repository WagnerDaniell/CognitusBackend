using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using CognitusBackend.Application.UseCase.Home;

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

        [HttpGet]
        [Route("home")]
        public async Task<ActionResult> Home(string token)
        {
            var useCase = new HomeUseCase(_context);

            var result = await useCase.executeHome(token);

            return Ok(result.Value);
        }

    }
}
