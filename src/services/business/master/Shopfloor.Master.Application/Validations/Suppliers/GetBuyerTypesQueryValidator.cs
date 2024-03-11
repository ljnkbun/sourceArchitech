using FluentValidation;
using Shopfloor.Master.Application.Query.Suppliers;

namespace Shopfloor.Master.Application.Validations.Suppliers
{
    public class GetSuppliersQueryValidator : AbstractValidator<GetSuppliersQuery>
    {
        public GetSuppliersQueryValidator()
        {
            RuleFor(p => p.WFXSupplierId)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
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
