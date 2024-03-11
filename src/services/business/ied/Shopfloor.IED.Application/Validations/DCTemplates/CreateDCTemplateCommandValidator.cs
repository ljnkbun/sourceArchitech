using FluentValidation;
using Shopfloor.IED.Application.Command.DCTemplates;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DCTemplates
{
    public class CreateDCTemplateCommandValidator : AbstractValidator<CreateDCTemplateCommand>
    {
        private readonly IDCTemplateRepository _dcTemplate;

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

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");

            RuleForEach(p => p.DCTemplateTasks).ChildRules(childDcTemplateTask =>
            {
                childDcTemplateTask.RuleFor(p => p.DyeingProcessId)
                .NotNull().WithMessage("{PropertyName} is required.");

                childDcTemplateTask.RuleFor(p => p.DyeingProcessName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDcTemplateTask.RuleFor(p => p.DyeingOpreationId)
                    .NotNull().WithMessage("{PropertyName} is required.");

                childDcTemplateTask.RuleFor(p => p.DyeingOpreationName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDcTemplateTask.RuleFor(p => p.LineNumber)
                    .NotNull().WithMessage("{PropertyName} is required.");

                childDcTemplateTask.RuleFor(p => p.MachineCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDcTemplateTask.RuleFor(p => p.MachineName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDcTemplateTask.RuleFor(p => p.Temperature)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                
                childDcTemplateTask.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");

                childDcTemplateTask.RuleForEach(p => p.DCTemplateDetails).ChildRules(childDcTemplateDetail =>
                {
                    childDcTemplateDetail.RuleFor(p => p.ChemicalCode)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

                    childDcTemplateDetail.RuleFor(p => p.ChemicalName)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                    childDcTemplateDetail.RuleFor(p => p.Unit)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                });
            });
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _dcTemplate.IsUniqueAsync(code);
        }
        private bool IsLineNumberUnique(CreateDCTemplateCommand command)
        {
            return command?.DCTemplateTasks.DistinctBy(m => m.LineNumber).Count() == command?.DCTemplateTasks.Count;
        }
    }
}