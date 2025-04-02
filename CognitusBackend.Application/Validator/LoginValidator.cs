using CognitusBackend.Application.DTOs.Request;
using FluentValidation;

namespace CognitusBackend.Application.Validator
{
    internal class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(6);
        }
    }
}
