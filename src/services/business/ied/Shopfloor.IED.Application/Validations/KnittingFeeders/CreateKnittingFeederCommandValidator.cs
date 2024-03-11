using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingFeeders;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingFeeders
{
    public class CreateKnittingFeederCommandValidator : AbstractValidator<CreateKnittingFeederCommand>
    {
        private readonly IKnittingFeederRepository _repository;
        public CreateKnittingFeederCommandValidator(IKnittingFeederRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
        }
        private async Task<bool> IsUniqueAsync(string name, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(name);
        }
    }
}
