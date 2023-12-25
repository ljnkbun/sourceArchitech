using FluentValidation;
using Microsoft.AspNetCore.Connections.Features;
using Shopfloor.Master.Application.Command.Strengths;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Strengths
{
    public class CreateStrengthCommandValidator : AbstractValidator<CreateStrengthCommand>
    {
        private readonly IStrengthRepository _strengthRepository;
        public CreateStrengthCommandValidator(IStrengthRepository strengthRepository)
        {
            _strengthRepository = strengthRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _strengthRepository.IsUniqueAsync(code);
        }
    }
}
