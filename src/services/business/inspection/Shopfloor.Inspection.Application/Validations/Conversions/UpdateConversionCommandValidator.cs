using FluentValidation;
using Shopfloor.Inspection.Application.Command.Conversions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.Conversions
{
    public class UpdateConversionCommandValidator : AbstractValidator<UpdateConversionCommand>
    {
        private readonly IConversionRepository _repository;
        public UpdateConversionCommandValidator(IConversionRepository repository)
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
             RuleFor(r => r.Value).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
        private async Task<bool> IsUniqueAsync(UpdateConversionCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
