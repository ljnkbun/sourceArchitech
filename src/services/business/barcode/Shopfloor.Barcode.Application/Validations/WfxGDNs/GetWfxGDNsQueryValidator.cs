using FluentValidation;
using Shopfloor.Barcode.Application.Query.WfxGDNs;

namespace Shopfloor.Barcode.Application.Validations.WfxGDNs
{
    public class GetWfxGDNsQueryValidator : AbstractValidator<GetWfxGDNsQuery>
    {
        public GetWfxGDNsQueryValidator()
        {
            RuleFor(p => p.WFXArticleCode)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SupplierName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.GDNNum)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ToOrderDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.GDNTypes)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

        }
    }

}
