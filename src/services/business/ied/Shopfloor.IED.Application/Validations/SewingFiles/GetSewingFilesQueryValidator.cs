using FluentValidation;
using Shopfloor.IED.Application.Query.SewingFiles;

namespace Shopfloor.IED.Application.Validations.SewingFiles
{
    public class GetSewingFilesQueryValidator : AbstractValidator<GetSewingFilesQuery>
    {
        public GetSewingFilesQueryValidator()
        {
            RuleFor(p => p.FileName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.FileId)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

        }
    }
}
