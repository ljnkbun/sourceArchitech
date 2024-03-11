using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingTypes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingTypes
{
    public class CreateKnittingTypeCommandValidator : AbstractValidator<CreateKnittingTypeCommand>
    {
        private readonly IKnittingTypeRepository _repository;

        public CreateKnittingTypeCommandValidator(IKnittingTypeRepository repository)
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
