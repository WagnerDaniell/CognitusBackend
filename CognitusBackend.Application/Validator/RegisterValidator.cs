using FluentValidation;
using CognitusBackend.Domain.Entities;
using CognitusBackend.Application.DTOs.Request;

namespace CognitusBackend.Application.Validator
{
    internal class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Schooling).NotEmpty().MaximumLength(100);
        }
    }
}
