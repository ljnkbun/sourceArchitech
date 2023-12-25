using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Validations.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportArticles
{
    public class UpdateImportArticleCommandValidator : AbstractValidator<UpdateImportArticleCommand>
    {
        public UpdateImportArticleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Deleted).WithMessage("{PropertyName} must null or greater than 0.");
            RuleFor(x => x.ArticleCode).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.ArticleName).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.GDNNumber).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite && (x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added)).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.FromSite).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite && (x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added)).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.ToSite).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite &&  (x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added)).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.SupplierName).NotEmpty().When(x => x.Type == ImportType.ImportPO && ( x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added)).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.OrderRefNum).NotEmpty().When(x => x.Type == ImportType.ImportPO && (x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added)).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.ColorName).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.ColorCode).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.SizeCode).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.UOM).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Units).GreaterThan(0).When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName} is required.");
            RuleForEach(x => x.ImportDetails).SetValidator(new UpdateImportDetailCommandValidator());
        }
    }
}
