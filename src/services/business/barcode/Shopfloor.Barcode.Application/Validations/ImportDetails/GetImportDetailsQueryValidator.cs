using FluentValidation;
using Shopfloor.Barcode.Application.Query.ImportDetails;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class GetImportDetailsQueryValidator : AbstractValidator<GetImportDetailsQuery>
    {
        public GetImportDetailsQueryValidator()
        {
            RuleFor(p => p.Color)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Size)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.UOM)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.OC)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Note)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.Unit)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Shade)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Status)
               .IsInEnum().WithMessage("Value is not part of the enum.");
            RuleFor(p => p.NumberOfCone)
              .GreaterThan(0).WithMessage(("{PropertyName} is required."));
            RuleFor(p => p.WeightPerCone)
               .GreaterThan(0).WithMessage(("{PropertyName} is required."));
            RuleFor(p => p.Quantity)
               .GreaterThan(0).WithMessage(("{PropertyName} is required."));
            RuleFor(p => p.ArticleName)
              .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.ArticleCode)
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Location)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
