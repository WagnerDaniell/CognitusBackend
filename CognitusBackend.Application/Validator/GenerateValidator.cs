using CognitusBackend.Application.DTOs.Request;
using FluentValidation;

namespace CognitusBackend.Application.Validator
{
    public class GenerateValidator : AbstractValidator<GenerateRequest>
    {
        public GenerateValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty();
        }
    }
}
