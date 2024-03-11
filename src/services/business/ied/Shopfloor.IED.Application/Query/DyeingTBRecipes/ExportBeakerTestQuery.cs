using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRecipes
{
    public class ExportBeakerTestQuery : IRequest<FileContentResult>
    {
        public int Id { get; set; }
    }

    public class ExportBeakerTestQueryHandler : IRequestHandler<ExportBeakerTestQuery, FileContentResult>
    {
        private readonly IDyeingTBRecipeRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportBeakerTestQueryHandler(
            IDyeingTBRecipeRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileContentResult> Handle(ExportBeakerTestQuery request, CancellationToken cancellationToken)
        {
            var beakerTest = await _repository.GetParentWithIncludeByIdAsync(request.Id);
            if (beakerTest == null)
                throw new Exception("Not found data");
            var dataExport = CellData(beakerTest);
            var fName = "TemplateBeakerTest.xls";
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "TemplateWFX", fName);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fName);
            var ms = ExportExcelHelper.WriteExcelHSSF(fullPath, dataExport);
            return new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fName,
                EnableRangeProcessing = true,
            };
        }

        private ExcelInputDataModel CellData(DyeingTBRecipe beakerTest)
        {
            var dataDicRows = new Dictionary<int, Dictionary<string, object>>
            {
                {
                    4,
                    new Dictionary<string, object>
                    {
                        { "C", beakerTest.Buyer },
                        { "H", beakerTest.DyeingTBMaterialColor.DyeingTBMaterial.FabricContent }
                    }
                },
                {
                    5,
                    new Dictionary<string, object>
                    {
                        { "C", beakerTest.DyeingTBMaterialColor.DyeingTBMaterial.DyeingTBRequest.StyleRef },
                        { "H", beakerTest.Color }
                    }
                },
                {
                    6,
                    new Dictionary<string, object>
                    {
                        { "C", beakerTest.TBRecipeNo },
                        { "H", beakerTest.TBRecipeName }
                    }
                },
                {
                    7,
                    new Dictionary<string, object>
                    {
                        { "C", beakerTest.DyeingTBMaterialColor.DyeingTBMaterial.Lights },
                        { "F", beakerTest.Concentration },
                        { "H", beakerTest.ApproveVersionIndex.ToAlphabet() },
                        { "K", beakerTest.ApproveDate }
                    }
                },
                {
                    44,
                    new Dictionary<string, object>
                    {
                        { "C", beakerTest.DyeingTBMaterialColor.DyeingTBMaterial.DyeingTBRequest.Remark }
                    }
                }
            };

            var dataDicCreateRows = new Dictionary<int, bool>
            {
                {
                    4,
                    false
                },
                {
                    5,
                    false
                },
                {
                    6,
                    false
                },
                {
                    7,
                    false
                },
                {
                    44,
                    false
                }
            };

            int ix = 10;
            foreach (var dyeingTaskDyeingTbrTask in beakerTest.DyeingTBRTasks)
            {
                foreach (var dyeingTaskDyeingTbrChemical in dyeingTaskDyeingTbrTask.DyeingTBRChemicals)
                {
                    dataDicRows.Add(
                        ix,
                        new Dictionary<string, object>
                        {
                            { "B", dyeingTaskDyeingTbrTask.DyeingProcessName },
                            { "C", dyeingTaskDyeingTbrTask.DyeingOperationName },
                            { "D", dyeingTaskDyeingTbrTask.MachineName },
                            { "F", dyeingTaskDyeingTbrTask.Temperature },
                            { "G", dyeingTaskDyeingTbrTask.Minute },
                            { "H", dyeingTaskDyeingTbrChemical.ChemicalName },
                            { "K", dyeingTaskDyeingTbrChemical.DyeingTBRChemicalValues.FirstOrDefault(x => x.VersionIndex == beakerTest.ApproveVersionIndex)?.Value },
                            { "L", dyeingTaskDyeingTbrChemical.Unit }
                        }
                    );

                    dataDicCreateRows.Add(
                        ix,
                        true
                    );
                    ix++;
                }
            }

            return new ExcelInputDataModel
            {
                DataDic = dataDicRows,
                DataCreateRows = dataDicCreateRows,
                SheetIndex = 0,
                ReFormat = true,
                Type = 1
            };
        }
    }
}