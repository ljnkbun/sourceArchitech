using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class UpdateImportDetailCommandValidator : AbstractValidator<UpdateImportDetailCommand>
    {
        private bool IsModifyOrDelete { get; set; }
        private bool IsModifyOrAdd { get; set; }
        public UpdateImportDetailCommandValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).When(x => IsModifyOrDelete).WithMessage("{PropertyName}  must null or greater than 0.");
            RuleFor(r => r.Color).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Size).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleName).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.UOM).NotEmpty().WithMessage("{PropertyName} is required.").When(y => y.Type == ImportType.ImportPO);
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).When(x => IsModifyOrAdd).WithMessage("{PropertyName}  is required.");
        }

        protected override bool PreValidate(ValidationContext<UpdateImportDetailCommand> context, ValidationResult result)
        {
            IsModifyOrDelete = context.InstanceToValidate.EntityState == EntityState.Modified || context.InstanceToValidate.EntityState == EntityState.Deleted;

            IsModifyOrAdd = context.InstanceToValidate.EntityState == EntityState.Modified || context.InstanceToValidate.EntityState == EntityState.Added;

            return true;
        }
    }
}
