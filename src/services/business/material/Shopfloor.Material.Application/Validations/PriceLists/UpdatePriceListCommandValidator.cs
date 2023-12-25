using FluentValidation;
using Shopfloor.Material.Application.Command.PriceLists;

namespace Shopfloor.Material.Application.Validations.PriceLists
{
    public class UpdatePriceListCommandValidator : AbstractValidator<UpdatePriceListCommand>
    {
        public UpdatePriceListCommandValidator()
        {
            RuleFor(p => p.CategoryCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.CategoryName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SupplierCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.SupplierName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleForEach(item => item.PriceListDetails).ChildRules(z =>
            {
                z.RuleFor(p => p.MaterialCode)
                    .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                z.RuleFor(p => p.ArticleName)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                z.RuleFor(p => p.Uom)
                    .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                z.RuleFor(p => p.DeliveryTerm)
                    .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                z.RuleFor(p => p.ValidFrom)
                    .LessThan(DateTime.Now.AddDays(1))
                    .GreaterThan(new DateTime(1970, 1, 1));

                z.RuleFor(p => p.ValidTo)
                    .GreaterThan(new DateTime(1970, 1, 1));

                z.RuleFor(p => p)
                    .Must(x => !x.ValidTo.HasValue || DateTime.Compare(x.ValidTo.Value, x.ValidFrom) >= 0)
                    .WithMessage("ValidTo must greater than or equal to ValidFrom.");
            });
        }
    }
}