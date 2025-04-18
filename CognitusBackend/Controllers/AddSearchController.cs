using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.UseCase.Search;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class AddSearchController : ControllerBase
    {
        private readonly Context _context;

        public AddSearchController(Context context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("addSearch")]
        public async Task<ActionResult> addSearch([FromBody] SearchRequest request)
        {
            var UseCase = new AddSearchUseCase(_context);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var guidId = Guid.Parse(userId);

            var response = await UseCase.executeAddSearch(request, guidId);

            return Ok(response.Value);
        }
    }
}
