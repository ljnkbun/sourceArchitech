using FluentValidation;
using Shopfloor.Material.Application.Models.PriceLists;

namespace Shopfloor.Material.Application.Validations.PriceLists
{
    public class DataImportPriceListCommandValidator : AbstractValidator<PriceListImportExcelModel>
    {
        public DataImportPriceListCommandValidator()
        {
            RuleFor(p => p.SupplierCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("SupplierCode must not exceed 200 characters.");

            RuleFor(p => p.ArticleCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("ArticleCode must not exceed 200 characters.");

            RuleFor(p => p.Price)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0");

            RuleFor(p => p.Currency)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Uom).MaximumLength(200).WithMessage("Uom must not exceed 200 characters.");

            RuleFor(p => p.DeliveryTerm).MaximumLength(200).WithMessage("DeliveryTerm must not exceed 200 characters.");

            RuleFor(p => p).Must(x => DateTime.Compare(x.ValidFrom, DateTime.Now.AddDays(1)) < 0 && DateTime.Compare(x.ValidFrom, new DateTime(1970, 1, 1)) >= 0).WithMessage("ValidFrom format is wrong");

            RuleFor(p => p).Must(x => !x.ValidTo.HasValue || DateTime.Compare(x.ValidTo.Value, new DateTime(1970, 1, 1)) >= 0).WithMessage("ValidTo format is wrong");

            RuleFor(p => p).Must(x => !x.ValidTo.HasValue || DateTime.Compare(x.ValidTo.Value, x.ValidFrom) >= 0).WithMessage("ValidTo must greater than or equal to ValidFrom.");
        }
    }
}