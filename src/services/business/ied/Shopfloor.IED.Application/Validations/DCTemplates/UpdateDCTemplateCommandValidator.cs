using FluentValidation;
using Shopfloor.IED.Application.Command.DCTemplates;

namespace Shopfloor.IED.Application.Validations.DCTemplates
{
    public class UpdateDCTemplateCommandValidator : AbstractValidator<UpdateDCTemplateCommand>
    {
        public UpdateDCTemplateCommandValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}