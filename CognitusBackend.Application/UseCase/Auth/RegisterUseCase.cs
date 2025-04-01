using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Application.Services;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Application.UseCase.Auth
{
    public class RegisterUseCase
    {
        private readonly Context _context;
        private readonly TokenService _tokenService;

        public RegisterUseCase(Context context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }

        public async Task<ActionResult<AuthResponse>> registerExecute(User user)
        {
            //preciso de uma validação geral

            var ExistingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (ExistingUser != null)
            {
                //return (new { message = "Email already in use" }); vou ter que fazer uma exception
            }
            
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception error)
            {
                //return (new { message = "Error on creating user" }); vou ter que fazer uma exception
            }

            var accessToken = _tokenService.GenerateToken(user);

            return new AuthResponse("Sucess: Cadastrado com sucesso!", accessToken);

        }
    }
}
