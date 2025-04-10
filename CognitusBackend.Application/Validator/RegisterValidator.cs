using FluentValidation;
using CognitusBackend.Domain.Entities;

namespace CognitusBackend.Application.Validator
{
    internal class RegisterValidator : AbstractValidator<User>
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
