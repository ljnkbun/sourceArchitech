using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportDetails;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class UpdateImportDetailCommandValidator : AbstractValidator<UpdateImportDetailCommand>
    {
        public UpdateImportDetailCommandValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).When(x => x.EntityState == EntityState.Deleted || x.EntityState== EntityState.Modified).WithMessage("{PropertyName}  must null or greater than 0.");
            RuleFor(r => r.Color).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Size).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleName).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.UOM).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Shade).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Note).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.NumberOfCone).NotNull().GreaterThan(0).When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.WeightPerCone).NotNull().GreaterThan(0).When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Unit).NotEmpty().When(x => x.EntityState == EntityState.Modified || x.EntityState == EntityState.Added).WithMessage("{PropertyName}  is required.");
        }
    }
}
