using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.QCDefinitions
{
    public class CreateQCDefinitionCommandValidator : AbstractValidator<CreateQCDefinitionCommand>
    {
        IQCDefinitionRepository _repository;
        public CreateQCDefinitionCommandValidator(IQCDefinitionRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Buyer).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Category).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.AcceptanceValue).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ConversionId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.QCTypeId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
