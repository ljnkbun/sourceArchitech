using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Application.Definitions;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;

namespace Shopfloor.Barcode.Application.Validations.ExportDetails
{
    internal class ImportDataExportDetailCommandValidator : AbstractValidator<ImportDataExportDetailCommand>
    {
        private readonly DataExportDetailCommandValidator _validationRules;
        private readonly IExportDetailRepository _exportDetailRepository;

        public ImportDataExportDetailCommandValidator(DataExportDetailCommandValidator validationRules, IExportDetailRepository exportDetailRepository)
        {

            _validationRules = validationRules;
            _exportDetailRepository = exportDetailRepository;
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
            RuleFor(p => p.File).CustomAsync(CustomCheckCreateExportDetailCmd);
        }

        private async Task CustomCheckCreateExportDetailCmd(IFormFile file, ValidationContext<ImportDataExportDetailCommand> context, CancellationToken token)
        {
            if (file != null)
            {
                var src = ImportExcelHelper.ReadExcel<ExportDetailExcelModel>(file, new ImportExcelModel(0, 2, FieldMaps.ExportDetail));
                if (src.Any())
                {
                    var exportDetails = await _exportDetailRepository.GetAllAsync();
                    if (exportDetails.Select(p => p.Code).Except(src.Select(p => p.Code)).Any())
                    {
                        var valids = new ValidationFailure("code", "Detail code must Unique.");
                        context.AddFailure(string.Join(Environment.NewLine, valids));
                    }

                    foreach (var item in src)
                    {
                        var valid = await _validationRules.ValidateAsync(item, token);
                        if (!valid.IsValid)
                            context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                    }
                }
            }
        }

    }
}
