using FluentValidation;
using Shopfloor.Barcode.Application.Query.BarcodeLocations;

namespace Shopfloor.Barcode.Application.Validations.BarcodeLocations
{
    public class GetBarcodeLocationsQueryValidator : AbstractValidator<GetBarcodeLocationsQuery>
    {
        public GetBarcodeLocationsQueryValidator()
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
