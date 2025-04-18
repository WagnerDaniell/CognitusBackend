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

        public async Task<ActionResult<HomeResponse>> executeHome(Guid Id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user == null)
            {
                throw new Exception("Error ao achar o user!");
            }

            var userLastSearch = await _context.UserSearches.FirstOrDefaultAsync(x => x.UserId == Id);

            if (userLastSearch == null)
            {
                return new HomeResponse(user.Name, "Você não tem assuntos recentes!");
            }

            return new HomeResponse(user.Name, userLastSearch.LastSearch);
        }
    }

}