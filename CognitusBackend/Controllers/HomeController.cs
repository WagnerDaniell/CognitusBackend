using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using CognitusBackend.Application.UseCase.Home;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CognitusBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class HomeController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IUserRepository _userRepository;

        public HomeController(Context context, ISearchRepository searchRepository, IUserRepository userRepository)
        {
            _searchRepository = searchRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("home")]
        public async Task<ActionResult> Home()
        {
            var useCase = new HomeUseCase(_searchRepository, _userRepository);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var guidId = Guid.Parse(userId);

            var result = await useCase.executeHome(guidId);

            return Ok(result.Value);
        }

    }
}
