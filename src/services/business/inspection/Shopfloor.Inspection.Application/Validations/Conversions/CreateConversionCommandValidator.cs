using FluentValidation;
using Shopfloor.Inspection.Application.Command.Conversions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.Conversions
{
    public class CreateConversionCommandValidator : AbstractValidator<CreateConversionCommand>
    {
        IConversionRepository _repository;
        public CreateConversionCommandValidator(IConversionRepository repository)
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
             RuleFor(r => r.Value).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
