using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingMachineDiameters;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingMachineDiameters
{
    public class CreateKnittingMachineDiameterCommandValidator : AbstractValidator<CreateKnittingMachineDiameterCommand>
    {
        private readonly IKnittingMachineDiameterRepository _repository;
        public CreateKnittingMachineDiameterCommandValidator(IKnittingMachineDiameterRepository repository)
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
