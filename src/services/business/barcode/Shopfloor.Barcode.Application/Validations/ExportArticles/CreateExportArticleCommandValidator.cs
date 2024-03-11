using FluentValidation;
using Shopfloor.Barcode.Application.Command.ExportArticles;

namespace Shopfloor.Barcode.Application.Validations.ExportArticles
{
    public class CreateExportArticleCommandValidator : AbstractValidator<CreateExportArticleCommand>
    {

        public CreateExportArticleCommandValidator()
        {

            RuleFor(p => p.ArticleCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ColorCode)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SizeCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Quantity)
               .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

            RuleFor(p => p.UOM)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.GDIType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.LocationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.DeliveryOC)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Note)
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.SummaryOC)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.GDINum)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");


            RuleForEach(p => p.ExportDetails).ChildRules(child =>
            {

                child.RuleFor(x => x.ExportArticleId)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();

                child.RuleFor(x => x.ColorCode)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.SizeCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.UOM)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.Shade)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(x => x.OC)
                   .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Location)
                   .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(x => x.Status)
                    .IsInEnum().WithMessage("Value is not part of the enum.");

                child.RuleFor(x => x.Note)
                   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
            });

        }


    }
}
