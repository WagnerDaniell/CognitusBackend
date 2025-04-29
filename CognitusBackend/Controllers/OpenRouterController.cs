using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.UseCase.OpenRouter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [Authorize]
        [HttpPost]
        [Route("generate")]
        public async Task<ActionResult> GenerateText([FromBody] GenerateRequest prompt)
        {
            var UseCase = new OpenRouterUseCase(_generate);

            var jsonResponse = await UseCase.executeGenerateQuest(prompt);

            return Ok(jsonResponse);
        }
    }
}
