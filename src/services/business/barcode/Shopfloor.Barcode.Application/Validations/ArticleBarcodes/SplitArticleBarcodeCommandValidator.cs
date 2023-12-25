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
                child.RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(p => p.Color)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.Size)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.Shade)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.OC)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(p => p.Location)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                child.RuleFor(p => p.UOM)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(r => r.Quantity)
                    .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

                child.RuleFor(r => r.NumberOfCone)
                    .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

                child.RuleFor(r => r.WeightPerCone)
                    .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

                child.RuleFor(r => r.Unit).NotEmpty().WithMessage("{PropertyName}  is required.");

                child.RuleFor(p => p.IsMain).NotNull()
                    .NotEmpty().WithMessage("{PropertyName} is required.");

                child.RuleFor(p => p.Note)
                   .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
            });


        }

    }
}
