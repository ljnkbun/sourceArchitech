using FluentValidation;
using Shopfloor.IED.Application.Command.SewingFeatureLibs;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Validations.SewingFeatureLibs
{
    public class UpdateSewingFeatureLibCommandValidator : AbstractValidator<UpdateSewingFeatureLibCommand>
    {
        public UpdateSewingFeatureLibCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.BuyerCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.BuyerName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategoryCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");

            RuleForEach(x => x.SewingFeatureLibBOLs).ChildRules(child =>
            {
                child.RuleFor(p => p.Code).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                child.RuleFor(p => p.Name).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                child.RuleFor(p => p.Freq).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                child.RuleFor(p => p.Type).IsInEnum().WithMessage("Type out of range.");
            });
        }
        private bool IsLineNumberUnique(UpdateSewingFeatureLibCommand command)
        {
            return command?.SewingFeatureLibBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingFeatureLibBOLs.Count;
        }
        private bool IsValid(UpdateSewingFeatureLibCommand command)
        {
            return command?.SewingFeatureLibBOLs.All(b => (b.Type == FeatureBOLType.OP && b.SewingOperationLibId != null)
                                                         || (b.Type == FeatureBOLType.CM && b.SewingOperationLibId == null)) ?? true;
        }
    }
}
