using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Application.Command.SewingOperations;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingOperations
{
    public class UpdateSewingOperationCommandValidator : AbstractValidator<UpdateSewingOperationCommand>
    {
        private readonly ISewingOperationRepository _SewingOperationRepository;
        public UpdateSewingOperationCommandValidator(ISewingOperationRepository SewingOperationRepository)
        {
            _SewingOperationRepository = SewingOperationRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleForEach(e => e.SewingOperationBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleForEach(e => e.SewingOperationBOLs).Must(r => r.Type.IsDefined()).WithMessage("Type out of range.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingOperationCommand command, CancellationToken token)
        {
            return await _SewingOperationRepository.IsUniqueAsync(command.Code, command.Id);
        }
        private bool IsLineNumberUnique(UpdateSewingOperationCommand command)
        {
            return command?.SewingOperationBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingOperationBOLs.Count();
        }
        private bool IsValid(UpdateSewingOperationCommand command)
        {
            return command?.SewingOperationBOLs.All(b => b.Type == OperationBOLType.Task && b.SewingTaskId != null ||
                                                         b.Type == OperationBOLType.Macro && b.SewingMacroId != null) ?? true;
        }
    }
}
