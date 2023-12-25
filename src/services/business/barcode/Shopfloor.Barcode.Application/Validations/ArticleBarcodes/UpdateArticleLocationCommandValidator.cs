using FluentValidation;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;
using Shopfloor.Barcode.Application.Validations.BarcodeLocations;

namespace Shopfloor.Barcode.Application.Validations.ArticleBarcodes
{
    public class UpdateArticleLocationCommandValidator : AbstractValidator<UpdateArticleLocationCommand>
    {
        public UpdateArticleLocationCommandValidator()
        {
            RuleFor(p => p.UpdateBarcodeLocationCommand).SetValidator(new UpdateBarcodeLocationCommandValidator());
        }

    }
}
