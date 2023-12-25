using FluentValidation;
using Shopfloor.Material.Application.Command.PriceLists;

namespace Shopfloor.Material.Application.Validations.PriceLists
{
    public class CreatePriceListCommandValidator : AbstractValidator<CreatePriceListCommand>
    {
        public CreatePriceListCommandValidator()
        {
            RuleForEach(item => item.Data).ChildRules(z =>
            {
                z.RuleFor(p => p.SupplierCode).MaximumLength(200).WithMessage("SupplierCode must not exceed 200 characters.");

                z.RuleFor(p => p.SupplierName).MaximumLength(500).WithMessage("SupplierName must not exceed 500 characters.");

                z.RuleFor(p => p.CategoryCode).MaximumLength(200).WithMessage("CategoryCode must not exceed 200 characters.");

                z.RuleFor(p => p.CategoryName).MaximumLength(500).WithMessage("CategoryName must not exceed 500 characters.");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => zx.MaterialCode.Length < 200)).WithMessage("MaterialCode must not exceed 200 characters.");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => zx.ArticleName.Length < 500)).WithMessage("ArticleName must not exceed 500 characters.");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => zx.Uom.Length < 200)).WithMessage("Uom must not exceed 200 characters.");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => zx.DeliveryTerm.Length < 200)).WithMessage("DeliveryTerm must not exceed 200 characters.");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => DateTime.Compare(zx.ValidFrom, DateTime.Now.AddDays(1)) < 0 && DateTime.Compare(zx.ValidFrom, new DateTime(1970, 1, 1)) >= 0)).WithMessage("ValidFrom format is wrong");

                z.RuleFor(p => p).Must(x => x.PriceListDetails.Any(zx => !zx.ValidTo.HasValue || DateTime.Compare(zx.ValidTo.Value, new DateTime(1970, 1, 1)) >= 0)).WithMessage("ValidTo format is wrong");

                z.RuleFor(p => p)
                    .Must(x => x.PriceListDetails.Any(zx => !zx.ValidTo.HasValue || DateTime.Compare(zx.ValidTo.Value, zx.ValidFrom) >= 0))
                    .WithMessage("ValidTo must greater than or equal to ValidFrom.");
            });
        }
    }
}