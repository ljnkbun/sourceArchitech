using FluentValidation;
using Shopfloor.IED.Application.Query.FolderTrees;

namespace Shopfloor.IED.Application.Validations.FolderTrees
{
    public class GetFolderTreesQueryValidator : AbstractValidator<GetFolderTreesQuery>
    {
        public GetFolderTreesQueryValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

        }
    }
}
