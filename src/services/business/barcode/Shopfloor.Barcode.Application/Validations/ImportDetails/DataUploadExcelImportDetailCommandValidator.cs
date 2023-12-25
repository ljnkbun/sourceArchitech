using FluentValidation;
using Shopfloor.Barcode.Application.Models.ImportPODetails;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class DataUploadExcelImportDetailCommandValidator : AbstractValidator<UploadExcelImportDetailModel>
    {
        public DataUploadExcelImportDetailCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ArticleName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
          

          
        }
    }
}