using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.UseCase.Search;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [Route("addSearch")]
        public async Task<ActionResult> addSearch([FromBody] SearchRequest request)
        {
            var UseCase = new AddSearchUseCase(_context);

            var response = await UseCase.executeAddSearch(request);

            return Ok(response.Value);
        }
    }
}
