using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.UseCase.Search;
using CognitusBackend.Domain.Exceptions;
using CognitusBackend.Domain.Repositories;
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
        private readonly ISearchRepository _searchRepository;

        public AddSearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [Authorize]
        [HttpPost]
        [Route("addSearch")]
        public async Task<ActionResult> addSearch([FromBody] string lastsearch)
        {
            var UseCase = new AddSearchUseCase(_searchRepository);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new NotFoundException("Id não encontrado!");
            }

            var guidId = Guid.Parse(userId);

            var newRequest = new SearchRequest
            {
                UserId = guidId,
                LastSearch = lastsearch,

            };

            var response = await UseCase.executeAddSearch(newRequest);

            return Ok(response.Value);
        }
    }
}
