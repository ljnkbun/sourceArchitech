using FluentValidation;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Validations.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportArticles
{
    public class CreateImportArticleCommandValidator : AbstractValidator<CreateImportArticleCommand>
    {
        public CreateImportArticleCommandValidator()
        {
            RuleFor(x => x.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.").When(y => y.Type == ImportType.ImportTransferToSite); ;
            RuleFor(x => x.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.").When(y => y.Type == ImportType.ImportTransferToSite); ;
            RuleFor(x => x.GDNNumber).NotEmpty().WithMessage("{PropertyName} is required.").When(y=>y.Type==ImportType.ImportTransferToSite);
            RuleFor(x => x.FromSite).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.ToSite).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.SupplierName).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.OrderRefNum).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.ColorCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.SizeCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.UOM).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Units).GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleForEach(x => x.ImportDetails).SetValidator( new CreateImportDetailCommandValidator());

        }
    }
}
