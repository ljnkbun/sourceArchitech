using FluentValidation;
using Shopfloor.IED.Application.Query.DCTemplateTasks;

namespace Shopfloor.IED.Application.Validations.DCTemplateTasks
{
    public class GetDCTemplateTasksQueryValidator : AbstractValidator<GetDCTemplateTasksQuery>
    {
        public GetDCTemplateTasksQueryValidator()
        {
            RuleFor(p => p.TaskCode)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Temperature)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TaskName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}