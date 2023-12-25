using FluentValidation;
using Shopfloor.IED.Application.Command.DCTemplates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DCTemplates
{
    public class CreateDCTemplateCommandValidator : AbstractValidator<CreateDCTemplateCommand>
    {
        private IDCTemplateRepository _dcTemplate;

        public CreateDCTemplateCommandValidator(IDCTemplateRepository dcTemplate)
        {
            _dcTemplate = dcTemplate;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueAsync)
                .WithMessage("Code must unique.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _dcTemplate.IsUniqueAsync(code);
        }
    }
}