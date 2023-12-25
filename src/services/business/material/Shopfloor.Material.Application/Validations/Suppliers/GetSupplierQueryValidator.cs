using FluentValidation;
using Shopfloor.Material.Application.Query.Suppliers;

namespace Shopfloor.Material.Application.Validations.Suppliers
{
    public class GetSupplierQueryValidator : AbstractValidator<GetSuppliersQuery>
    {
        public GetSupplierQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}