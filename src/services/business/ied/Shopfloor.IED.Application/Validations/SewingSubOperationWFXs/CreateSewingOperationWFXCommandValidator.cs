using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXs;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Validations.SewingSubOperationWFXs
{
    public class CreateSewingSubOperationWFXCommandValidator : AbstractValidator<CreateSewingSubOperationWFXCommand>
    {
        public CreateSewingSubOperationWFXCommandValidator()
        {
            RuleFor(p => p.WFXProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.WFXProcessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.LineCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.LineNumber)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.QuatityPoints)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.QualityComments)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Freq)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleForEach(e => e.SewingSubOperationWFXBOLs).Must(r => r.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleForEach(e => e.SewingSubOperationWFXBOLs).Must(r => r.Type.IsDefined()).WithMessage("Type out of range.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");
        }
        private bool IsLineNumberUnique(CreateSewingSubOperationWFXCommand command)
        {
            return command?.SewingSubOperationWFXBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingSubOperationWFXBOLs.Count();
        }
        private bool IsValid(CreateSewingSubOperationWFXCommand command)
        {
            return command?.SewingSubOperationWFXBOLs.All(b => b.Type == SubOperationWFXBOLType.Operation && b.SewingOperationId != null ||
                                                         b.Type == SubOperationWFXBOLType.Feature && b.SewingFeatureId != null) ?? true;
        }
    }
}
