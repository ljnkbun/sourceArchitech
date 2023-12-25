using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Helpers;
using Shopfloor.Material.Application.Definitions;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.MaterialRequests
{
    public class ExportMaterialRequestQuery : IRequest<FileContentResult>
    {
        public int[] Ids { get; set; }

        public string Type { get; set; }
    }

    public class ExportMaterialRequestQueryHandler : IRequestHandler<ExportMaterialRequestQuery, FileContentResult>
    {
        private readonly IMaterialRequestRepository _repository;
        private readonly IDynamicColumnRepository _repositoryDynamicColumn;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportMaterialRequestQueryHandler(
            IMaterialRequestRepository repository, IWebHostEnvironment webHostEnvironment, IDynamicColumnRepository repositoryDynamicColumn)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _repositoryDynamicColumn = repositoryDynamicColumn;
        }

        public async Task<FileContentResult> Handle(ExportMaterialRequestQuery request, CancellationToken cancellationToken)
        {
            if (request.Ids == null || request.Ids.Length == 0)
                throw new ArgumentNullException(nameof(request.Ids));
            var data = new List<Dictionary<string, object>>();
            var materialRequests = await _repository.GetMaterialRequestByIdsAsync(request.Ids);
            string fname;
            switch (request.Type)
            {
                case MaterialRequestType.Trims:
                    {
                        fname = "ArticleTrimsMaster.xls";
                        foreach (var material in materialRequests)
                            data.Add(await CellData(material, request.Type));

                        if (data.Count == 0)
                            throw new Exception("Not found data");
                        break;
                    }
                case MaterialRequestType.Fabric:
                    {
                        fname = "ArticleTextileFabricMaster.xls";
                        foreach (var material in materialRequests)
                            data.Add(await CellData(material, request.Type));

                        if (data.Count == 0)
                            throw new Exception("Not found data");
                        break;
                    }
                case MaterialRequestType.Yarns:
                    {
                        fname = "ArticleYarnMaster.xls";
                        foreach (var material in materialRequests)
                            data.Add(await CellData(material, request.Type));

                        if (data.Count == 0)
                            throw new Exception("Not found data");
                        break;
                    }
                case MaterialRequestType.Misc:
                    {
                        fname = "ArticleMiscMaster.xls";
                        foreach (var material in materialRequests)
                            data.Add(await CellData(material, request.Type));

                        if (data.Count == 0)
                            throw new Exception("Not found data");
                        break;
                    }
                default:
                    throw new Exception("Not found data");
            }
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "TemplateWFX", fname);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fname);
            var ms = ExportExcelHelper.WriteExcelHSSF(fullPath, new ExcelInputDataModel
            {
                Data = data,
                RowIndex = 1,
                SheetIndex = 0
            });
            return new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fname,
                EnableRangeProcessing = true,
            };
        }

        private async Task<Dictionary<string, object>> CellData(MaterialRequest material, string type)
        {
            var dic = new Dictionary<string, object>();
            switch (type)
            {
                case MaterialRequestType.Trims:
                    {
                        dic.Add("A", material.ProductGroupName);
                        dic.Add("B", material.ProductSubCatName);
                        dic.Add("C", string.IsNullOrEmpty(material.ArticleCode) ? "." : material.ArticleCode);
                        dic.Add("D", material.ArticleName);
                        dic.Add("E", material.ArticleDesc);
                        dic.Add("F", material.FabricAndMaterial);
                        dic.Add("G", material.ColorTypeName);
                        dic.Add("H", material.ColorGroupName);
                        dic.Add("I", material.SizeGroupName);
                        dic.Add("J", material.SeasonName);
                        dic.Add("K", material.DivisionName);
                        dic.Add("L", material.UomName);
                        dic.Add("M", material.StoringUomName);
                        dic.Add("N", material.OurContactName);
                        dic.Add("O", material.BuyerName);
                        dic.Add("P", material.BuyerRef);
                        dic.Add("Q", material.SupplierName);
                        dic.Add("R", material.SupplierRef);
                        dic.Add("S", material.BuyingPrice);
                        dic.Add("T", material.BuyingCurrencyName);
                        dic.Add("U", material.PricePerName);
                        dic.Add("V", material.MinimumQty);
                        dic.Add("W", material.MaximumQty);
                        dic.Add("X", material.MinimumOrderQty);
                        dic.Add("Y", material.RequirementMultiple);
                        dic.Add("Z", material.ReorderLevel);
                        dic.Add("AA", material.OrderQtyMultiple);
                        dic.Add("AB", material.Remarks);
                        dic.Add("AC", material.CatalogPath);
                        dic.Add("AD", material.MaterialTypeName);
                        dic.Add("AE", material.ConsUomName);
                        dic.Add("AF", material.HSNCode);
                        dic.Add("AG", material.ArticleNameChinese);
                        var dynamicColumn = await _repositoryDynamicColumn.GetDynamicColumnByCodesAsync(DynamicColumnType.TrimsDc, MaterialRequestType.Trims);
                        dic.Add("AH", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "ButtonType"))
                            ?.Value ?? "");
                        dic.Add("AI", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "ButtonHole"))
                            ?.Value ?? "");
                        dic.Add("AJ", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "ElasticType"))
                            ?.Value ?? "");
                        dic.Add("AK", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "RivetType"))
                            ?.Value ?? "");
                        dic.Add("AL", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "ZipperType"))
                            ?.Value ?? "");
                        dic.Add("AM", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Layer"))
                            ?.Value ?? "");
                        dic.Add("AN", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Brand"))
                            ?.Value ?? "");
                        dic.Add("AO", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Tex"))
                            ?.Value ?? "");
                        break;
                    }
                case MaterialRequestType.Fabric:
                    {
                        dic.Add("A", material.ProductGroupName);
                        dic.Add("B", material.ProductSubCatName);
                        dic.Add("C", string.IsNullOrEmpty(material.ArticleCode) ? "." : material.ArticleCode);
                        dic.Add("D", material.ArticleName);
                        dic.Add("E", material.ArticleDesc);
                        dic.Add("F", material.ColorTypeName);
                        dic.Add("G", material.ColorGroupName);
                        dic.Add("H", material.SizeGroupName);
                        dic.Add("I", material.SeasonName);
                        dic.Add("J", material.DivisionName);
                        dic.Add("K", material.UomName);
                        dic.Add("L", material.StoringUomName);
                        dic.Add("M", material.BuyerRef);
                        dic.Add("N", material.SupplierName);
                        dic.Add("O", material.SupplierRef);
                        dic.Add("P", material.BuyingPrice);
                        dic.Add("Q", material.BuyingCurrencyName);
                        dic.Add("R", material.CountName);
                        dic.Add("S", material.ConstructionName);
                        dic.Add("T", material.ContentName);
                        dic.Add("U", material.PricePerName);
                        dic.Add("V", material.DesignAndPattern);
                        dic.Add("W", material.Weight);
                        dic.Add("X", material.MinimumQty);
                        dic.Add("Y", material.MaximumQty);
                        dic.Add("Z", material.MinimumOrderQty);
                        dic.Add("AA", material.RequirementMultiple);
                        dic.Add("AB", material.ReorderLevel);
                        dic.Add("AC", material.OrderQtyMultiple);
                        dic.Add("AD", material.PerSizeConsName);
                        dic.Add("AE", material.CatalogPath);
                        dic.Add("AF", material.MaterialTypeName);
                        dic.Add("AG", material.ConsUomName);
                        dic.Add("AH", string.Join(',', material.FabricCompositions.Select(x => $"{x.ContentNameDesc}:{x.Percentage}")));
                        dic.Add("AI", material.HSNCode);
                        dic.Add("AJ", material.ArticleNameChinese);
                        var dynamicColumn = await _repositoryDynamicColumn.GetDynamicColumnByCodesAsync(DynamicColumnType.FabricDc, MaterialRequestType.Fabric);
                        dic.Add("AK", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "TCFNO"))
                            ?.Value ?? "");
                        dic.Add("AL", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "GSM"))
                            ?.Value ?? "");
                        dic.Add("AM", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "NoOfEnds"))
                            ?.Value ?? "");
                        dic.Add("AN", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "SpinningMethod"))
                            ?.Value ?? "");
                        dic.Add("AO", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Certificate"))
                            ?.Value ?? "");
                        dic.Add("AP", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Gauge"))
                            ?.Value ?? "");
                        dic.Add("AQ", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "StitchLength"))
                            ?.Value ?? "");
                        dic.Add("AR", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "YarnComposition"))
                            ?.Value ?? "");
                        dic.Add("AS", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "CutWidth"))
                            ?.Value ?? "");
                        dic.Add("AT", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Structure"))
                            ?.Value ?? "");
                        break;
                    }
                case MaterialRequestType.Yarns:
                    {
                        dic.Add("A", material.ProductGroupName);
                        dic.Add("B", material.ProductSubCatName);
                        dic.Add("C", string.IsNullOrEmpty(material.ArticleCode) ? "." : material.ArticleCode);
                        dic.Add("D", material.ArticleName);
                        dic.Add("E", material.ArticleDesc);
                        dic.Add("F", material.ColorTypeName);
                        dic.Add("G", material.ColorGroupName);
                        dic.Add("H", material.SizeGroupName);
                        dic.Add("I", material.SeasonName);
                        dic.Add("J", material.DivisionName);
                        dic.Add("K", material.UomName);
                        dic.Add("L", material.StoringUomName);
                        dic.Add("M", material.OurContactName);
                        dic.Add("N", material.BuyerRef);
                        dic.Add("O", material.SupplierName);
                        dic.Add("P", material.SupplierRef);
                        dic.Add("Q", material.BuyingPrice);
                        dic.Add("R", material.BuyingCurrencyName);
                        dic.Add("S", material.CountName);
                        dic.Add("T", material.ConstructionName);
                        dic.Add("U", material.ContentName);
                        dic.Add("V", material.PricePerName);
                        dic.Add("W", material.DesignAndPattern);
                        dic.Add("X", material.MinimumOrder);
                        dic.Add("Y", material.MinimumQty);
                        dic.Add("Z", material.MaximumQty);
                        dic.Add("AA", material.MinimumOrderQty);
                        dic.Add("AB", material.RequirementMultiple);
                        dic.Add("AC", material.ReorderLevel);
                        dic.Add("AD", material.OrderQtyMultiple);
                        dic.Add("AE", material.PerSizeConsName);
                        dic.Add("AF", material.CatalogPath);
                        dic.Add("AG", material.MaterialTypeName);
                        dic.Add("AH", material.ConsUomName);
                        dic.Add("AI", material.InternalPrice);
                        dic.Add("AJ", material.Finish);
                        dic.Add("AK", material.HSNCode);
                        dic.Add("AL", material.HTSCode);
                        var dynamicColumn = await _repositoryDynamicColumn.GetDynamicColumnByCodesAsync(DynamicColumnType.YarnDc, MaterialRequestType.Yarns);
                        dic.Add("AM", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "SpinningMethod"))
                            ?.Value ?? "");
                        dic.Add("AN", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "CountType"))
                            ?.Value ?? "");
                        dic.Add("AO", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Certificate"))
                            ?.Value ?? "");
                        dic.Add("AP", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "SpinningProcess"))
                            ?.Value ?? "");
                        dic.Add("AQ", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Pattern"))
                            ?.Value ?? "");
                        dic.Add("AR", material.DynamicColumns
                            .FirstOrDefault(x => dynamicColumn.Any(y => y.Id == x.DynamicColumnId && y.Code == "Twist"))
                            ?.Value ?? "");
                        break;
                    }
                case MaterialRequestType.Misc:
                    {
                        dic.Add("A", material.ProductGroupName);
                        dic.Add("B", material.ProductSubCatName);
                        dic.Add("C", string.IsNullOrEmpty(material.ArticleCode) ? "." : material.ArticleCode);
                        dic.Add("D", material.ArticleName);
                        dic.Add("E", material.ArticleDesc);
                        dic.Add("F", material.UomName);
                        dic.Add("G", material.StoringUomName);
                        dic.Add("H", material.BuyerName);
                        dic.Add("I", material.BuyerRef);
                        dic.Add("J", material.SupplierName);
                        dic.Add("K", material.SupplierRef);
                        dic.Add("L", material.BuyingPrice);
                        dic.Add("M", material.BuyingCurrencyName);
                        dic.Add("N", material.MinimumQty);
                        dic.Add("O", material.MaximumQty);
                        dic.Add("P", material.ReorderLevel);
                        dic.Add("Q", material.CatalogPath);
                        dic.Add("R", material.MaterialTypeName);
                        dic.Add("S", material.MinimumOrderQty);
                        dic.Add("T", material.OrderQtyMultiple);
                        break;
                    }
            }
            return dic;
        }
    }
}