using FluentValidation;
using Shopfloor.IED.Application.Command.Formulas;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Formulas
{
    public class CreateFormulaCommandValidator : AbstractValidator<CreateFormulaCommand>
    {
        private readonly IFormulaRepository _formulaRepository;
        public CreateFormulaCommandValidator(IFormulaRepository formulaRepository)
        {
            _formulaRepository = formulaRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Expression)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _formulaRepository.IsUniqueAsync(code);
        }
    }
}
