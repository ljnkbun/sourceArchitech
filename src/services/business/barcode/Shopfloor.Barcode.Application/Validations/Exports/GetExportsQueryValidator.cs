using FluentValidation;
using Shopfloor.Barcode.Application.Query.Exports;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.Exports
{
    public class GetExportsQueryValidator : AbstractValidator<GetExportsQuery>
    {
        public GetExportsQueryValidator()
        {
            RuleFor(p => p.Code)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");


            RuleFor(p => p.Statuses).Custom((str, context) =>
            {
                if (str != null)
                {
                    var arrCheckedEnum = str.Split(',').Select(x => Enum.TryParse(typeof(ExportStatus), x, out var rs));
                    if (arrCheckedEnum.Contains(false))
                    {
                        context.AddFailure("Statuses not in Enum");
                    }
                }
            });

            RuleFor(p => p.Types).Custom((str, context) =>
            {
                if (str != null)
                {
                    var arrCheckedEnum = str.Split(',').Select(x => Enum.TryParse(typeof(ExportTypes), x, out var rs));
                    if (arrCheckedEnum.Contains(false))
                    {
                        context.AddFailure("Types not in Enum");
                    }
                }
            });


            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

        }
    }
}
