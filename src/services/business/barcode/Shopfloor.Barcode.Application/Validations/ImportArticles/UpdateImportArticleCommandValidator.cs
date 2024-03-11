using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Validations.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportArticles
{
    public class UpdateImportArticleCommandValidator : AbstractValidator<UpdateImportArticleCommand>
    {
        private bool IsModifyOrDelete { get; set; }
        private bool IsModifyOrAdd { get; set; }

        public UpdateImportArticleCommandValidator()
        {

            RuleFor(x => x.Id).GreaterThan(0).When(x => IsModifyOrDelete).WithMessage("{PropertyName} must null or greater than 0.");
            RuleFor(x => x.ArticleCode).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.ArticleName).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.GDNNumber).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite && IsModifyOrAdd).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.FromSite).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite && IsModifyOrAdd).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.ToSite).NotEmpty().When(x => x.Type == ImportType.ImportTransferToSite && IsModifyOrAdd).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(x => x.SupplierName).NotEmpty().When(x => x.Type == ImportType.ImportPO && IsModifyOrAdd).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.OrderRefNum).NotEmpty().When(x => x.Type == ImportType.ImportPO && IsModifyOrAdd).WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.UOM).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(x => x.ColorName).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.ColorCode).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.SizeCode).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).When(x => IsModifyOrAdd).WithMessage("{PropertyName} is required.");

            RuleForEach(x => x.ImportDetails).SetValidator(new UpdateImportDetailCommandValidator());
        }

        protected override bool PreValidate(ValidationContext<UpdateImportArticleCommand> context, ValidationResult result)
        {
            IsModifyOrDelete = context.InstanceToValidate.EntityState == EntityState.Modified || context.InstanceToValidate.EntityState == EntityState.Deleted;

            IsModifyOrAdd = context.InstanceToValidate.EntityState == EntityState.Modified || context.InstanceToValidate.EntityState == EntityState.Added;

            return true;
        }
    }
}
