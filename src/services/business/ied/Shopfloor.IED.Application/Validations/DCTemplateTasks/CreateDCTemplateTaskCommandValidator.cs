using FluentValidation;
using Shopfloor.IED.Application.Command.DCTemplateTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DCTemplateTasks
{
    public class CreateDCTemplateTaskCommandValidator : AbstractValidator<CreateDCTemplateTaskCommand>
    {
        private readonly IDCTemplateRepository _dcTemplate;

        public CreateDCTemplateTaskCommandValidator(IDCTemplateRepository dcTemplate)
        {
            _dcTemplate = dcTemplate;

            RuleFor(p => p.TaskCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Temperature)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TaskName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DCTemplateId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dcTemplateId, CancellationToken token)
        {
            return await _dcTemplate.IsExistAsync(dcTemplateId);
        }
    }
}