using FluentValidation;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Material.Application.Command.MaterialRequests;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Application.Models.MaterialRequests;

namespace Shopfloor.Material.Application.Validations.MaterialRequests
{
    public class ImportMaterialRequestCommandValidator : AbstractValidator<ImportMaterialRequestCommand>
    {
        private readonly ImportFabricMaterialRequestCommandValidator _fabricMaterialRequestCommandValidator;
        private readonly ImportMiscMaterialRequestCommandValidator _miscMaterialRequestCommandValidator;
        private readonly ImportYarnsMaterialRequestCommandValidator _yarnsMaterialRequestCommandValidator;
        private readonly ImportTrimsMaterialRequestCommandValidator _trimsMaterialRequestCommandValidator;

        public ImportMaterialRequestCommandValidator(ImportFabricMaterialRequestCommandValidator fabricMaterialRequestCommandValidator, ImportMiscMaterialRequestCommandValidator miscMaterialRequestCommandValidator, ImportYarnsMaterialRequestCommandValidator yarnsMaterialRequestCommandValidator, ImportTrimsMaterialRequestCommandValidator trimsMaterialRequestCommandValidator)
        {
            _fabricMaterialRequestCommandValidator = fabricMaterialRequestCommandValidator;
            _miscMaterialRequestCommandValidator = miscMaterialRequestCommandValidator;
            _yarnsMaterialRequestCommandValidator = yarnsMaterialRequestCommandValidator;
            _trimsMaterialRequestCommandValidator = trimsMaterialRequestCommandValidator;

            RuleFor(x => x.Type).NotEmpty().NotNull().WithMessage("{PropertyName} is required.");
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
            RuleFor(p => p).CustomAsync(CustomCheckCreateMaterialRequestCmd);
        }

        private async Task CustomCheckCreateMaterialRequestCmd(ImportMaterialRequestCommand command, ValidationContext<ImportMaterialRequestCommand> context, CancellationToken token)
        {
            if (command.File != null || !string.IsNullOrEmpty(command.Type))
            {
                var src = new List<MaterialImportExcelModel>();
                switch (command.Type)
                {
                    case MaterialRequestType.Trims:
                    {
                        src = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(command.File, new ImportExcelModel(0, 2, FieldMaps.TrimsRequest));
                        if (src is { Count: > 0 })
                        {
                            foreach (var item in src)
                            {
                                var valid = await _trimsMaterialRequestCommandValidator.ValidateAsync(item, token);
                                if (!valid.IsValid)
                                    context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                            }
                        }
                        else
                        {
                            context.AddFailure(string.Join(Environment.NewLine, "No data import"));
                        }
                        break;
                    }
                    case MaterialRequestType.Fabric:
                    {
                        src = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(command.File, new ImportExcelModel(0, 2, FieldMaps.FabricRequest));
                        if (src is { Count: > 0 })
                        {
                            foreach (var item in src)
                            {
                                var valid = await _fabricMaterialRequestCommandValidator.ValidateAsync(item, token);
                                if (!valid.IsValid)
                                    context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                            }
                        }
                        else
                        {
                            context.AddFailure(string.Join(Environment.NewLine, "No data import"));
                        }
                        break;
                    }
                    case MaterialRequestType.Misc:
                    {
                        src = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(command.File, new ImportExcelModel(0, 2, FieldMaps.MiscRequest));
                        if (src is { Count: > 0 })
                        {
                            foreach (var item in src)
                            {
                                var valid = await _miscMaterialRequestCommandValidator.ValidateAsync(item, token);
                                if (!valid.IsValid)
                                    context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                            }
                        }
                        else
                        {
                            context.AddFailure(string.Join(Environment.NewLine, "No data import"));
                        }
                        break;
                    }
                    case MaterialRequestType.Yarns:
                    {
                        src = ImportExcelHelper.ReadExcel<MaterialImportExcelModel>(command.File, new ImportExcelModel(0, 2, FieldMaps.YarnsRequest));
                        if (src is { Count: > 0 })
                        {
                            foreach (var item in src)
                            {
                                var valid = await _yarnsMaterialRequestCommandValidator.ValidateAsync(item, token);
                                if (!valid.IsValid)
                                    context.AddFailure(string.Join(Environment.NewLine, valid.Errors));
                            }
                        }
                        else
                        {
                            context.AddFailure(string.Join(Environment.NewLine, "No data import"));
                        }
                        break;
                    }
                    default:
                    {
                        context.AddFailure(string.Join(Environment.NewLine, "Type wrong format"));
                        break;
                    }
                }
            }
        }
    }
}