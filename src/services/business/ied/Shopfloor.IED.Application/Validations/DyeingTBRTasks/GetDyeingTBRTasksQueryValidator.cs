using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRTasks;

namespace Shopfloor.IED.Application.Validations.DyeingTBRTasks
{
    public class GetDyeingTBRTasksQueryValidator : AbstractValidator<GetDyeingTBRTasksQuery>
    {
        public GetDyeingTBRTasksQueryValidator()
        {
            RuleFor(p => p.DyeingProcessName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DyeingOperationName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.MachineCode)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MachineName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}