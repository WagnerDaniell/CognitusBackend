using System.IdentityModel.Tokens.Jwt;
using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace CognitusBackend.Application.UseCase.Search
{
    public class AddSearchUseCase
    {
        private readonly Context _context;

        public AddSearchUseCase(Context context)
        {
             _context = context;
        }

        public async Task<ActionResult<MessageResponse>> executeAddSearch(SearchRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(request.token) as JwtSecurityToken;

            var userId = jwtToken?.Claims.FirstOrDefault(c => c.Type == "nameid");

            var Id = userId?.Value;

            var GuidId = Guid.Parse(Id);

            var newDataSearch = new UserSearch
            {
                LastSearch = request.LastSearch,
                UserId = GuidId,

            };

            await _context.UserSearches.AddAsync(newDataSearch);
            await _context.SaveChangesAsync();

            return new MessageResponse("Nova Search adicionada!");
        }
    }
}
