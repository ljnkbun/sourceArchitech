using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Material.Application.Command.PriceLists;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.PriceLists;

namespace Shopfloor.Material.Application.Validations.PriceLists
{
    public class ImportPriceListCommandValidator : AbstractValidator<ImportPriceListCommand>
    {
        private readonly DataImportPriceListCommandValidator _dataImportPriceListCommandValidator;

        public ImportPriceListCommandValidator(DataImportPriceListCommandValidator dataImportPriceListCommandValidator)
        {
            _dataImportPriceListCommandValidator = dataImportPriceListCommandValidator;
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
                if (v == null)
                    return false;
                var size = v.Length;
                if (size > 5242880)
                    return false;
                return true;
            }).WithMessage(x => $"File upload too large.");
            RuleFor(p => p.File).CustomAsync(CustomCheckCreatePriceListCmd);
        }

        private async Task CustomCheckCreatePriceListCmd(IFormFile file, ValidationContext<ImportPriceListCommand> context, CancellationToken token)
        {
            if (file != null)
            {
                var src = ImportExcelHelper.ReadExcel<PriceListImportExcelModel>(file, new ImportExcelModel(0, 2, FieldMaps.PriceList));
                if (src is { Count: > 0 })
                {
                    foreach (var item in src)
                    {
                        var valid = await _dataImportPriceListCommandValidator.ValidateAsync(item, token);
                        if (!valid.IsValid)
                            context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                    }
                }
            }
        }
    }
}