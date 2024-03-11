using FluentValidation;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;

namespace Shopfloor.Barcode.Application.Validations.ArticleBarcodes
{
    public class SplitArticleBarcodeCommandValidator : AbstractValidator<SplitArticleBarcodeCommand>
    {

        public SplitArticleBarcodeCommandValidator()
        {
            RuleForEach(x => x.SplitDetailModels).ChildRules(child =>
            {
                child.RuleFor(r => r.Quantity)
                    .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");
            });


        }

    }
}
