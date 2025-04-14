using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Application.UseCase.Home
{
    public class HomeUseCase
    {
        private readonly Context _context;

        public HomeUseCase(Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<HomeResponse>> executeHome(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            var userId = jwtToken?.Claims.FirstOrDefault(c => c.Type == "nameid");

            var Id = userId?.Value;

            if (Id == null)
            {
                throw new Exception("Error ao achar o userId!");
            }

            var guidId = Guid.Parse(Id);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == guidId);

            if (user == null)
            {
                throw new Exception("Error ao achar o user!");
            }

            var userLastSearch = await _context.UserSearches.FirstOrDefaultAsync(x => x.UserId == guidId);

            if (userLastSearch == null)
            {
                return new HomeResponse(user.Name, "Você não tem assuntos recentes!");
            }

            return new HomeResponse(user.Name, userLastSearch.LastSearch);
        }
    }

}