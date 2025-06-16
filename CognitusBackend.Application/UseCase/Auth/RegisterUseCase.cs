using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Application.Services;
using CognitusBackend.Application.Validator;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Domain.Exceptions;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CognitusBackend.Application.UseCase.Auth
{
    public class RegisterUseCase
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public RegisterUseCase(TokenService token, IUserRepository repository)
        {
            _tokenService = token;
            _userRepository = repository;
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

            var ExistingUser = await _userRepository.getByEmailAsync(user.Email);

            if (ExistingUser != null)
            {
                throw new UnauthorizedException("Usuário já cadastrado!");
            }

            try
            {
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

                await _userRepository.setUserAsync(newUser);

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
