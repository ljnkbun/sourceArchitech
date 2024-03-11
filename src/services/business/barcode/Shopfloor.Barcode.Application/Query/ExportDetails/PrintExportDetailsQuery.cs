using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Application.Query.ExportDetails
{
    public class PrintExportDetailsQuery : IRequest<ICollection<PrintExportDetailModel>>
    {
        public string Ids { get; set; }
        public CategoryType CategoryType { get; set; }
    }
    public class PrintExportDetailsQueryHandler : IRequestHandler<PrintExportDetailsQuery, ICollection<PrintExportDetailModel>>
    {
        private readonly IExportDetailRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public PrintExportDetailsQueryHandler(
            IExportDetailRepository repository
            , IRequestClientService requestClientService
            )
        {
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<ICollection<PrintExportDetailModel>> Handle(PrintExportDetailsQuery request, CancellationToken cancellationToken)
        {
            var intIds = request.Ids.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            var exportDetails = await _repository.GetByIdsAsync(intIds);

            var rs = new List<PrintExportDetailModel>();
            MassTransit.Response<GetArticlessResponse> articleReqs = null;
            try
            {
                articleReqs = await _requestClientService.GetResponseAsync<GetArticlessRequest, GetArticlessResponse>(new GetArticlessRequest()
                {
                    ArticleCode =  exportDetails.Select(o => o.ArticleCode).ToList()
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            var articles = articleReqs?.Message?.Data;

            foreach (var exportDetail in exportDetails)
            {
                var article = articles?.FirstOrDefault(x => x.ArticleCode == exportDetail.ArticleCode);
                if (article != null && article.Category != null)
                {
                    switch (article.Category)
                    {
                        case nameof(CategoryType.Apparel):
                            break;
                        case nameof(CategoryType.Yarns):
                            rs.Add(new()
                            {
                                Id = exportDetail.Id,
                                ArticleCode = exportDetail.ArticleCode,
                                ArticleName = exportDetail.ArticleName,
                                Category = article.Category,
                                PONo = string.Empty,
                                ArticleBarcode = exportDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = exportDetail.Quantity,
                                PackingNo = article.PackingTypeName,
                                LotNo = exportDetail.Location,
                                Color = exportDetail.ColorCode,
                                Composition = article.FabricMaterial,
                                WeightPerCone = exportDetail.WeightPerCone,
                                UOM = exportDetail.UOM,
                            });
                            break;
                        case nameof(CategoryType.Fabric):
                        case nameof(CategoryType.TextilesFabric):
                            rs.Add(new()
                            {
                                Id = exportDetail.Id,
                                ArticleCode = article.ArticleCode,
                                ArticleName = article.ArticleName,
                                Category = article.Category,
                                PONo = string.Empty,
                                ArticleBarcode = exportDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = exportDetail.Quantity,
                                RollNo = exportDetail.ExportArticle?.Quantity.ToString(),
                                LotNo = exportDetail.Location,
                                Color = exportDetail.ColorCode,
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                WeightPerCone = exportDetail.WeightPerCone,
                                UOM = exportDetail.UOM,
                            });
                            break;
                        case nameof(CategoryType.Fiber):
                            rs.Add(new()
                            {
                                Id = exportDetail.Id,
                                ArticleCode = article.ArticleCode,
                                ArticleName = article.ArticleName,
                                Category = article.Category,
                                PONo = string.Empty,
                                ArticleBarcode = exportDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = exportDetail.Quantity,
                                BaleNo = exportDetail.ExportArticle?.Quantity.ToString(),
                                Staple = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.STAPLE)?.AttributeValue,
                                Origin = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.ORIGIN)?.AttributeValue,
                                Micronaire = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.MICRONAIRE)?.AttributeValue,
                                LotNo = exportDetail.Location,
                                Color = exportDetail.ColorCode,
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                WeightPerCone = exportDetail.WeightPerCone,
                                UOM = exportDetail.UOM,
                            });
                            break;
                        default:

                            rs.Add(new()
                            {
                                Id = exportDetail.Id,
                                ArticleCode = exportDetail.ArticleCode,
                                ArticleName = exportDetail.ArticleName,
                                Category = article.Category,
                                PONo = string.Empty,
                                ArticleBarcode = exportDetail.ArticleBarcode?.Barcode,
                                SupplierName = exportDetail.ArticleBarcode?.SupplierName,
                                SubCategory = article.ProductSubCategory,
                                Quantity = exportDetail.Quantity,
                                PackingNo = article.PackingTypeName,
                                LotNo = exportDetail.Location,
                                Color = exportDetail.ColorCode,
                                Composition = string.Empty,
                                WeightPerCone = exportDetail.WeightPerCone,
                                UOM = exportDetail.UOM,
                                RollNo = exportDetail.ExportArticle?.Quantity.ToString(),
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                BaleNo = exportDetail.ExportArticle?.Quantity.ToString(),
                                Staple = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.STAPLE)?.AttributeValue,
                                Origin = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.ORIGIN)?.AttributeValue,
                                Micronaire = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.MICRONAIRE)?.AttributeValue,
                            }); break;
                    }
                }
                else
                {
                    rs.Add(new()
                    {
                        Id = exportDetail.Id,
                        ArticleCode = exportDetail.ArticleCode,
                        ArticleName = exportDetail.ArticleName,
                        Category = string.Empty,
                        PONo = string.Empty,
                        ArticleBarcode = exportDetail.ArticleBarcode?.Barcode,
                        SupplierName = exportDetail.ArticleBarcode?.SupplierName,
                        SubCategory = string.Empty,
                        Quantity = exportDetail.Quantity,
                        PackingNo = string.Empty,
                        LotNo = exportDetail.Location,
                        Color = exportDetail.ColorCode,
                        Composition = string.Empty,
                        WeightPerCone = exportDetail.WeightPerCone,
                        UOM = exportDetail.UOM,
                        RollNo = exportDetail.ExportArticle?.Quantity.ToString(),
                        GarmentStyle = string.Empty,
                        Reference = string.Empty,
                        BaleNo = exportDetail.ExportArticle?.Quantity.ToString(),
                        Staple = null,
                        Origin = null,
                        Micronaire = null,
                    });
                }
            }


            return rs;
        }
    }
}
