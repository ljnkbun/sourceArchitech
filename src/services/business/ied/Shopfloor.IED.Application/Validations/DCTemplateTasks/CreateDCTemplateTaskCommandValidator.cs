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

            RuleFor(p => p.DyeingProcessId)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.DyeingProcessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.DyeingOpreationId)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.DyeingOpreationName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.LineNumber)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.MachineCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.MachineName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Temperature)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.DCTemplateId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.DCTemplateDetails).ChildRules(childDCTemplateDetail =>
            {
                childDCTemplateDetail.RuleFor(p => p.ChemicalId)
                    .NotNull().WithMessage("{PropertyName} is required.");

                childDCTemplateDetail.RuleFor(p => p.ChemicalCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

                childDCTemplateDetail.RuleFor(p => p.ChemicalName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDCTemplateDetail.RuleFor(p => p.Unit)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            });
        }

        private async Task<bool> IsExistAsync(int dcTemplateId, CancellationToken token)
        {
            return await _dcTemplate.IsExistAsync(dcTemplateId);
        }
    }
}