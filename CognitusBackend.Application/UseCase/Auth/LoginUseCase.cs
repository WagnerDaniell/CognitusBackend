using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Application.Services;
using CognitusBackend.Domain.Exceptions;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CognitusBackend.Application.Validator;
using CognitusBackend.Domain.Repositories;

namespace CognitusBackend.Application.UseCase.Auth
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public LoginUseCase(TokenService token, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenService = token;
        }

        public async Task<ActionResult<AuthResponse>> executeLogin(LoginRequest login)
        {
            var validator = new LoginValidator();
            var resultValidation = validator.Validate(login);

            if(!resultValidation.IsValid)
            {
                throw new UnauthorizedException("O Payload não está no formato correto!");
            }   

            var user = await _userRepository.getByEmailAsync(login.Email);

            if (user == null)
            {
                throw new NotFoundException("Usuario não encontrado!");
            }

            if(!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                throw new UnauthorizedException("Senha incorreta!");
            }

            var accessToken = _tokenService.GenerateToken(user);

            return new AuthResponse("Sucess: Logado com sucesso!", accessToken);
        }
    }
}
