using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.QCDefinitions
{
    public class UpdateQCDefinitionCommandValidator : AbstractValidator<UpdateQCDefinitionCommand>
    {
        private readonly IQCDefinitionRepository _repository;
        public UpdateQCDefinitionCommandValidator(IQCDefinitionRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleFor(p => p.Buyer).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Category).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.AcceptanceValue).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.SamplingId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ConversionId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.QCTypeId).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
        private async Task<bool> IsUniqueAsync(UpdateQCDefinitionCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
