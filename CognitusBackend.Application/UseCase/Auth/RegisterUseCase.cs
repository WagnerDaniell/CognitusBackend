using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Application.Services;
using CognitusBackend.Application.Validator;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Domain.Exceptions;
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

        public async Task<ActionResult<AuthResponse>> registerExecute(RegisterRequest user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Schooling = user.Schooling
            };

            var validation = new RegisterValidator();
            var resultValidation = validation.Validate(user);

            if (!resultValidation.IsValid)
            {
                throw new UnauthorizedException("O Payload não está no formato correto!");
            }

            var ExistingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (ExistingUser != null)
            {
                throw new UnauthorizedException("Usuário já cadastrado!");
            }

            try
            {
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception error)
            {
                throw new Exception("Erro ao cadastrar usuário: " + error.Message);
            }

            var accessToken = _tokenService.GenerateToken(newUser);

            return new AuthResponse("Sucess: Cadastrado com sucesso!", accessToken);

        }
    }
}
