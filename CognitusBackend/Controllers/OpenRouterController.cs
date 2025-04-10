using CognitusBackend.Application.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace CognitusBackend.Api.Controllers
{
    [ApiController]
    [Route("api/c")]
    public class OpenRouterController : ControllerBase
    {
        private readonly OpenRouterService _generate;

        public OpenRouterController(OpenRouterService generate)
        {
            _generate = generate;
        }

        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult> GenerateText([FromBody] GenerateRequest prompt)
        {
                    var result = await _generate.GenerateTextAsync(prompt);
            return Ok(result);
        }
    }
}
