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

        public async Task<ActionResult<MessageResponse>> executeAddSearch(SearchRequest request, Guid id)
        {
            var newDataSearch = new UserSearch
            {
                LastSearch = request.LastSearch,
                UserId = id,

            };

            await _context.UserSearches.AddAsync(newDataSearch);
            await _context.SaveChangesAsync();

            return new MessageResponse("Nova Search adicionada!");
        }
    }
}
