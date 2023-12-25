using FluentValidation;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.BarcodeLocations
{
    public class CreateBarcodeLocationCommandValidator : AbstractValidator<CreateBarcodeLocationCommand>
    {
        public CreateBarcodeLocationCommandValidator()
        {
            RuleFor(p => p.LocationId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");

            RuleFor(p => p.ArticleBarcodeId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");
        }
    }
}
