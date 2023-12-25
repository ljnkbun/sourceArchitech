using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingMacros
{
    public class CreateSewingMacroCommandValidator : AbstractValidator<CreateSewingMacroCommand>
    {
        private readonly ISewingMacroRepository _SewingMacroRepository;
        public CreateSewingMacroCommandValidator(ISewingMacroRepository SewingMacroRepository)
        {
            _SewingMacroRepository = SewingMacroRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleForEach(e => e.SewingMacroBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _SewingMacroRepository.IsUniqueAsync(code);
        }
        private bool IsLineNumberUnique(CreateSewingMacroCommand command)
        {
            return command?.SewingMacroBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingMacroBOLs.Count();
        }
    }
}
