using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingMacros
{
    public class UpdateSewingMacroCommandValidator : AbstractValidator<UpdateSewingMacroCommand>
    {
        private readonly ISewingMacroRepository _sewingMacroRepository;
        public UpdateSewingMacroCommandValidator(ISewingMacroRepository sewingMacroRepository)
        {
            _sewingMacroRepository = sewingMacroRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleForEach(e => e.SewingMacroBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");

        }
        private async Task<bool> IsUniqueAsync(UpdateSewingMacroCommand command, CancellationToken token)
        {
            return await _sewingMacroRepository.IsUniqueAsync(command.Code, command.Id);
        }
        private bool IsLineNumberUnique(UpdateSewingMacroCommand command)
        {
             return command?.SewingMacroBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingMacroBOLs.Count();
        }
    }
}
