using FluentValidation;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Validations.ImportTransferToSiteDetails
{
    public class GetImportTransferToSiteSyncsQueryValidator : AbstractValidator<ImportTransferToSiteSync>
    {
        public GetImportTransferToSiteSyncsQueryValidator()
        {
            RuleFor(r => r.ArticleName).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).MaximumLength(50).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Color).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.UOM).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.StoringUOM).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.GDNNo).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FromSite).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToSite).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.OC).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.LotNo).MaximumLength(200).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Qty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
