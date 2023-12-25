using FluentValidation;
using Shopfloor.IED.Application.Command.Formulas;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Formulas
{
    public class UpdateFormulaCommandValidator : AbstractValidator<UpdateFormulaCommand>
    {
        private readonly IFormulaRepository _formulaRepository;
        public UpdateFormulaCommandValidator(IFormulaRepository formulaRepository)
        {
            _formulaRepository = formulaRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

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

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateFormulaCommand command, CancellationToken token)
        {
            return await _formulaRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
