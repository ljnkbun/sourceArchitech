using FluentValidation;
using Shopfloor.IED.Application.Command.FormulaFields;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.FormulaFields
{
    public class UpdateFormulaFieldCommandValidator : AbstractValidator<UpdateFormulaFieldCommand>
    {
        private readonly IFormulaFieldRepository _formulaFieldRepository;
        public UpdateFormulaFieldCommandValidator(IFormulaFieldRepository formulaFieldRepository)
        {
            _formulaFieldRepository = formulaFieldRepository;

            RuleFor(p => p.FieldName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("FieldName must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateFormulaFieldCommand command, CancellationToken token)
        {
            return await _formulaFieldRepository.IsUniqueAsync(command.FieldName, command.Id);
        }
    }
}
