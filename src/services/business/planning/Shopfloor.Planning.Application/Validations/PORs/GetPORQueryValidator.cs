using FluentValidation;
using Shopfloor.Planning.Application.Query.PORs;

namespace Shopfloor.Planning.Application.Validations.PORs
{
    public class GetPORQueryValidator : AbstractValidator<GetPORsQuery>
    {
        public GetPORQueryValidator()
        {
            RuleFor(p => p.PORNo)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ArticleCode)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.OCNo)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Category)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategory)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters."); 
            
            RuleFor(p => p.JobOrderNo)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

             RuleFor(p => p.ProductGroup)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BOMNo)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.TypePOR)
                .IsInEnum()
                .WithMessage("Value is not part of the enum.");
            
            RuleFor(p => p.DivisionName)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.UOM)
              .MaximumLength(250)
              .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DeliveryDate)
               .LessThan(DateTime.Now.AddDays(1))
               .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.CreatedDate)
               .LessThan(DateTime.Now.AddDays(1))
               .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
