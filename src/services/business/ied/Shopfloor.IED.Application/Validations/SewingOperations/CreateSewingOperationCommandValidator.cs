using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Application.Command.SewingOperations;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingOperations
{
    public class CreateSewingOperationCommandValidator : AbstractValidator<CreateSewingOperationCommand>
    {
        private readonly ISewingOperationRepository _SewingOperationRepository;
        public CreateSewingOperationCommandValidator(ISewingOperationRepository SewingOperationRepository)
        {
            _SewingOperationRepository = SewingOperationRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleForEach(e => e.SewingOperationBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleForEach(e => e.SewingOperationBOLs).Must(r => r.Type.IsDefined()).WithMessage("Type out of range.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");

        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _SewingOperationRepository.IsUniqueAsync(code);
        }
        private bool IsLineNumberUnique(CreateSewingOperationCommand command)
        {
            return command?.SewingOperationBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingOperationBOLs.Count();
        }
        private bool IsValid(CreateSewingOperationCommand command)
        {
            return command?.SewingOperationBOLs.All(b => b.Type == OperationBOLType.Task && b.SewingTaskId != null ||
                                                         b.Type == OperationBOLType.Macro && b.SewingMacroId != null) ?? true;
        }
    }
}
