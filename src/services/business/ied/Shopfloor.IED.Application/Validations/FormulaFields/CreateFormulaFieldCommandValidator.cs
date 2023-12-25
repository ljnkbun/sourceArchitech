using FluentValidation;
using Shopfloor.IED.Application.Command.FormulaFields;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.FormulaFields
{
    public class CreateFormulaFieldCommandValidator : AbstractValidator<CreateFormulaFieldCommand>
    {
        private readonly IFormulaFieldRepository _FormulaFieldRepository;
        public CreateFormulaFieldCommandValidator(IFormulaFieldRepository FormulaFieldRepository)
        {
            _FormulaFieldRepository = FormulaFieldRepository;

            RuleFor(p => p.FieldName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.ProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _FormulaFieldRepository.IsUniqueAsync(code);
        }
    }
}
