using CognitusBackend.Application.DTOs.Request;
using CognitusBackend.Application.DTOs.Response;
using CognitusBackend.Application.Validator;
using CognitusBackend.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CognitusBackend.Application.UseCase.OpenRouter
{
    public class OpenRouterUseCase
    {
        private readonly OpenRouterService _openRouterService;
        public OpenRouterUseCase(OpenRouterService openRouterService)
        {
            _openRouterService = openRouterService;
        }

        public async Task<string> executeGenerateQuest(GenerateRequest prompt)
        {
            var validor = new GenerateValidator();
            var validationResult = validor.Validate(prompt);

            if(!validationResult.IsValid)
            {
                throw new UnauthorizedException("Tema inválido!");
            }

            var result = await _openRouterService.GenerateTextAsync(prompt.Message);

            return result;
        }
    }
}
