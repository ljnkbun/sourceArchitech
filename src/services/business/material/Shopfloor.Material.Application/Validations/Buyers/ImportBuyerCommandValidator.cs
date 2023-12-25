using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Material.Application.Command.Buyers;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.Buyers;

namespace Shopfloor.Material.Application.Validations.Buyers
{
    public class ImportBuyerCommandValidator : AbstractValidator<ImportBuyerCommand>
    {
        private readonly DataImportBuyerCommandValidator _dataImportBuyerCommandValidator;

        public ImportBuyerCommandValidator(DataImportBuyerCommandValidator dataImportBuyerCommandValidator)
        {
            _dataImportBuyerCommandValidator = dataImportBuyerCommandValidator;
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
            RuleFor(p => p.File).CustomAsync(CustomCheckCreateBuyerCmd);
        }

        private async Task CustomCheckCreateBuyerCmd(IFormFile file, ValidationContext<ImportBuyerCommand> context, CancellationToken token)
        {
            if (file != null)
            {
                var src = ImportExcelHelper.ReadExcel<BuyerImportExcelModel>(file, new ImportExcelModel(0, 2, FieldMaps.Buyer));
                if (src is { Count: > 0 })
                {
                    foreach (var item in src)
                    {
                        var valid = await _dataImportBuyerCommandValidator.ValidateAsync(item, token);
                        if (!valid.IsValid)
                            context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                    }
                }
            }
        }
    }
}