using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRequestFiles;

namespace Shopfloor.IED.Application.Validations.DyeingTBRequestFiles
{
    public class GetDyeingTBRequestFilesQueryValidator : AbstractValidator<GetDyeingTBRequestFilesQuery>
    {
        public GetDyeingTBRequestFilesQueryValidator()
        {
            RuleFor(p => p.FileId)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.FileName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}