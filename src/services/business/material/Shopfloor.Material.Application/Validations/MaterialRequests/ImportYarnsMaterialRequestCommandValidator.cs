using FluentValidation;
using Shopfloor.Material.Application.Models.MaterialRequests;

namespace Shopfloor.Material.Application.Validations.MaterialRequests
{
    public class ImportYarnsMaterialRequestCommandValidator : AbstractValidator<MaterialImportExcelModel>
    {
        public ImportYarnsMaterialRequestCommandValidator()
        {
            RuleFor(p => p.ProductGroupCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ProductSubCatCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ArticleName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.UomCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.StoringUomCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SupplierName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}