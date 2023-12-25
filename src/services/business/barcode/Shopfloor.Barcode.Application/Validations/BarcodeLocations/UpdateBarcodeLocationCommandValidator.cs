using FluentValidation;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;

namespace Shopfloor.Barcode.Application.Validations.BarcodeLocations
{
    public class UpdateBarcodeLocationCommandValidator : AbstractValidator<UpdateBarcodeLocationCommand>
    {
        public UpdateBarcodeLocationCommandValidator()
        {

            RuleFor(p => p.LocationId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");

            RuleFor(p => p.ArticleBarcodeId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");
        }
    }
}
