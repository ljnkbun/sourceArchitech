using FluentValidation;
using Shopfloor.Inspection.Application.Query.Inpection4PointSyss;

namespace Shopfloor.Inspection.Application.Validations.Inpection4PointSyss
{
    public class GetInpection4PointSyssQueryValidator : AbstractValidator<GetInpection4PointSyssQuery>
    {
        public GetInpection4PointSyssQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.StockMovementNo).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Grade).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

        }
    }
}
