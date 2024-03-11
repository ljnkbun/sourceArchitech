using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Models.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class PrintImportDetailsQuery : IRequest<ICollection<PrintImportDetailModel>>
    {
        public string Ids { get; set; }
        public CategoryType CategoryType { get; set; }
    }
    public class PrintImportDetailsQueryHandler : IRequestHandler<PrintImportDetailsQuery, ICollection<PrintImportDetailModel>>
    {
        private readonly IImportDetailRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public PrintImportDetailsQueryHandler(
            IImportDetailRepository repository
            , IRequestClientService requestClientService
            )
        {
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<ICollection<PrintImportDetailModel>> Handle(PrintImportDetailsQuery request, CancellationToken cancellationToken)
        {
            var intIds = request.Ids.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            var importDetails = await _repository.GetByIdsAsync(intIds);

            var rs = new List<PrintImportDetailModel>();

            MassTransit.Response<GetArticlessResponse> articleReqs = null;
            try
            {
                articleReqs = await _requestClientService.GetResponseAsync<GetArticlessRequest, GetArticlessResponse>(new GetArticlessRequest()
                {
                    ArticleCode = importDetails.Select(o => o.ArticleCode).ToList()
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            var articles = articleReqs?.Message?.Data;

            foreach (var importDetail in importDetails)
            {
                var article = articles?.FirstOrDefault(x => x.ArticleCode == importDetail.ArticleCode);
                if (article != null && article.Category != null)
                {
                    switch (article.Category)
                    {
                        case nameof(CategoryType.Apparel):
                            break;
                        case nameof(CategoryType.Yarns):
                            rs.Add(new()
                            {
                                Id = importDetail.Id,
                                ArticleCode = importDetail.ArticleCode,
                                ArticleName = importDetail.ArticleName,
                                Category = article.Category,
                                PONo = importDetail.ArticleBarcode?.PONo,
                                ArticleBarcode = importDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = importDetail.Quantity,
                                PackingNo = article.PackingTypeName,
                                LotNo = importDetail.Location,
                                Color = importDetail.Color,
                                Composition = article.FabricMaterial,
                                WeightPerCone = importDetail.WeightPerCone,
                                UOM = importDetail.UOM,
                            });
                            break;
                        case nameof(CategoryType.Fabric):
                        case nameof(CategoryType.TextilesFabric):
                            rs.Add(new()
                            {
                                Id = importDetail.Id,
                                ArticleCode = article.ArticleCode,
                                ArticleName = article.ArticleName,
                                Category = article.Category,
                                PONo = importDetail.ArticleBarcode?.PONo,
                                ArticleBarcode = importDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = importDetail.Quantity,
                                RollNo = importDetail.ImportArticle?.Quantity.ToString(),
                                LotNo = importDetail.Location,
                                Color = importDetail.Color,
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                WeightPerCone = importDetail.WeightPerCone,
                                UOM = importDetail.UOM,
                            });
                            break;
                        case nameof(CategoryType.Fiber):
                            rs.Add(new()
                            {
                                Id = importDetail.Id,
                                ArticleCode = article.ArticleCode,
                                ArticleName = article.ArticleName,
                                Category = article.Category,
                                PONo = importDetail.ArticleBarcode?.PONo,
                                ArticleBarcode = importDetail.ArticleBarcode?.Barcode,
                                SupplierName = article.Supplier,
                                SubCategory = article.ProductSubCategory,
                                Quantity = importDetail.Quantity,
                                BaleNo = importDetail.ImportArticle?.Quantity.ToString(),
                                Staple = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.STAPLE)?.AttributeValue,
                                Origin = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.ORIGIN)?.AttributeValue,
                                Micronaire = article.FlexFieldList?.FirstOrDefault(x => x.AttributeName == FlexFieldConstant.MICRONAIRE)?.AttributeValue,
                                LotNo = importDetail.Location,
                                Color = importDetail.Color,
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                WeightPerCone = importDetail.WeightPerCone,
                                UOM = importDetail.UOM,
                            });
                            break;
                        default:

                            rs.Add(new()
                            {
                                Id = importDetail.Id,
                                ArticleCode = importDetail.ArticleCode,
                                ArticleName = importDetail.ArticleName,
                                Category = article.Category,
                                PONo = importDetail.ArticleBarcode?.PONo,
                                ArticleBarcode = importDetail.ArticleBarcode?.Barcode,
                                SupplierName = importDetail.ArticleBarcode?.SupplierName,
                                SubCategory = article.ProductSubCategory,
                                Quantity = importDetail.Quantity,
                                PackingNo = article.PackingTypeName,
                                LotNo = importDetail.Location,
                                Color = importDetail.Color,
                                Composition = string.Empty,
                                WeightPerCone = importDetail.WeightPerCone,
                                UOM = importDetail.UOM,
                                RollNo = importDetail.ImportArticle?.Quantity.ToString(),
                                GarmentStyle = article.FabricMaterial,
                                Reference = article.Reference,
                                BaleNo = importDetail.ImportArticle?.Quantity.ToString(),
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
                        Id = importDetail.Id,
                        ArticleCode = importDetail.ArticleCode,
                        ArticleName = importDetail.ArticleName,
                        Category = string.Empty,
                        PONo = importDetail.ArticleBarcode?.PONo,
                        ArticleBarcode = importDetail.ArticleBarcode?.Barcode,
                        SupplierName = importDetail.ArticleBarcode?.SupplierName,
                        SubCategory = string.Empty,
                        Quantity = importDetail.Quantity,
                        PackingNo = string.Empty,
                        LotNo = importDetail.Location,
                        Color = importDetail.Color,
                        Composition = string.Empty,
                        WeightPerCone = importDetail.WeightPerCone,
                        UOM = importDetail.UOM,
                        RollNo = importDetail.ImportArticle?.Quantity.ToString(),
                        GarmentStyle = string.Empty,
                        Reference = string.Empty,
                        BaleNo = importDetail.ImportArticle?.Quantity.ToString(),
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
