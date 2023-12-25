using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Application.Definitions;
using Shopfloor.Barcode.Application.Models.ImportPODetails;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class UploadExcelImportDetailCommandValidator : AbstractValidator<UploadExcelImportDetailCommand>
    {
        private readonly DataUploadExcelImportDetailCommandValidator _dataUploadExcelImportDetailCommandValidator;

        public UploadExcelImportDetailCommandValidator(DataUploadExcelImportDetailCommandValidator  validations)
        {
            _dataUploadExcelImportDetailCommandValidator = validations;
            RuleFor(x => x.File).NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.File).Must((v) =>
            {
                if (v == null)
                    return false;
                var extension = Path.GetExtension(v.FileName).ToLower();
                if (!new string[] { ".xls" }.Contains(extension))
                    return false;
                return true;
            }).WithMessage(x => $"Excel accept only.xls.");
            RuleFor(p => p.File).Must((v) =>
            {
                if (v == null) return false;
                var size = v.Length;
                if (size > 5242880)
                    return false;
                return true;
            }).WithMessage(x => $"File upload too large.");
            RuleFor(p => p.File).CustomAsync(CustomCheckData);
        }

        private async Task CustomCheckData(IFormFile file, ValidationContext<UploadExcelImportDetailCommand> context, CancellationToken token)
        {
            if (file != null)
            {
              
                var src = ImportExcelHelper.ReadExcel<UploadExcelImportDetailModel>(file, new ImportExcelModel(0, 2, FieldMaps.ImportDetails));
                if (src is { Count: > 0 })
                {
                    foreach (var item in src)
                    {
                        var valid = await _dataUploadExcelImportDetailCommandValidator.ValidateAsync(item, token);
                        if (!valid.IsValid)
                            context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                    }
                }
                else
                    context.AddFailure("No data import");
            }
        }
    }
}