using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Material.Application.Command.Suppliers;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.Suppliers;

namespace Shopfloor.Material.Application.Validations.Suppliers
{
    public class ImportSupplierCommandValidator : AbstractValidator<ImportSupplierCommand>
    {
        private readonly DataImportSupplierCommandValidator _dataImportSupplierCommandValidator;

        public ImportSupplierCommandValidator(DataImportSupplierCommandValidator dataImportSupplierCommandValidator)
        {
            _dataImportSupplierCommandValidator = dataImportSupplierCommandValidator;
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
            RuleFor(p => p.File).CustomAsync(CustomCheckCreateSupplierCmd);
        }

        private async Task CustomCheckCreateSupplierCmd(IFormFile file, ValidationContext<ImportSupplierCommand> context, CancellationToken token)
        {
            if (file != null)
            {
                var src = ImportExcelHelper.ReadExcel<SupplierImportExcelModel>(file, new ImportExcelModel(0, 2, FieldMaps.Supplier));
                if (src is { Count: > 0 })
                {
                    foreach (var item in src)
                    {
                        var valid = await _dataImportSupplierCommandValidator.ValidateAsync(item, token);
                        if (!valid.IsValid)
                            context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                    }
                }
                else
                {
                    context.AddFailure(string.Join(Environment.NewLine, "No data import"));
                }
            }
        }
    }
}