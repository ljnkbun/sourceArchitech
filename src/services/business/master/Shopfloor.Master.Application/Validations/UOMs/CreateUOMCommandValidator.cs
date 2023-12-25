using FluentValidation;
using Shopfloor.Master.Application.Command.UOMs;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.UOMs
{
    public class CreateUOMCommandValidator : AbstractValidator<CreateUOMCommand>
    {
        private readonly IUOMRepository _uOMrepository;
        public CreateUOMCommandValidator(IUOMRepository uOMRepository)
        {
            _uOMrepository = uOMRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Action)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _uOMrepository.IsUniqueAsync(code);
        }
    }
}
