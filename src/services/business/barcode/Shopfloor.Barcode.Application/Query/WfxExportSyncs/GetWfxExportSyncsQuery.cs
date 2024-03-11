using AutoMapper;
using MediatR;
using Serilog;
using Shopfloor.Barcode.Application.Models.WfxExportSyncs;
using Shopfloor.Barcode.Application.Parameters.WfxExportSyncs;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Application.Query.WfxExportSyncs
{
    public class GetWfxExportSyncsQuery : IRequest<PagedResponse<IReadOnlyList<WfxExportSyncDataModel>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }

        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }

    }

    public class GetWfxExportSyncEntitiesQueryHandler : IRequestHandler<GetWfxExportSyncsQuery, PagedResponse<IReadOnlyList<WfxExportSyncDataModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleBarcodeRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public GetWfxExportSyncEntitiesQueryHandler(IMapper mapper,
            IArticleBarcodeRepository repository
            , IRequestClientService requestClientService
            )
        {
            _mapper = mapper;
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxExportSyncDataModel>>> Handle(GetWfxExportSyncsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxExportSyncParameter>(request);
            var barcodes = (await _repository.GetPagedReponseAsync(validFilter))?.Data;

            var barcodeGroupByArticleCode = barcodes.GroupBy(x => x.ArticleCode);

            var articles = new List<WfxArticleDto>();
            var dataSearch = new Dictionary<string, string>
            {
                { "CreatedFrom", barcodes.ToList()[0]?.CreatedDate.Value.ToString("yyyy-MM-dd") }
            };
            try
            {
                var resp = await _requestClientService.GetResponseAsync<GetWfxArticleRequest, GetWfxArticleResponse>(new GetWfxArticleRequest
                {
                    SearchDics = dataSearch
                }, cancellationToken);
                articles = resp?.Message?.Data.Where(x => barcodes.Select(o => o.ArticleCode).Contains(x.ArticleCode)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            var datas = new List<WfxExportSyncDataModel>();

            foreach (var category in barcodeGroupByArticleCode)
            {
                foreach (var b in barcodes)
                {
                    var artcile = articles?.Find(x => x.ArticleCode == b.ArticleCode);
                    datas.Add(new()
                    {
                        ColorCode = b.Color,
                        ColorName = artcile?.BaseColorList?.Find(x => x.ColorCode == b.Color)?.ColorName,
                        FPPOOCNUm = b.OC,
                        GDINum = b.ExportDetails?.FirstOrDefault()?.ExportArticle.GDINum,
                        GDIType = b.ExportDetails?.FirstOrDefault()?.ExportArticle.GDIType.ToString(),
                        Location = b.Location,
                        OrderRefNum = request.OrderRefNum,
                        ParentRollBarcode = string.Empty,
                        RollBarCode = b.Barcode,
                        RollNo = b.Quantity.ToString(),
                        RollUnits = b.Quantity,
                        Shade = b.Shade,
                        SizeCode = b.Size,
                        SizeName = artcile?.BaseSizeList?.Find(x => x.SizeCode == b.Size)?.SizeName,
                        UOM = b.BarcodeUOM,
                        WareHouse = string.Empty,
                        WFXArticleCode = b.ArticleCode,
                        WFXArticleName = b.ArticleName
                    });
                }

            }
            var rs = new PagedResponse<IReadOnlyList<WfxExportSyncDataModel>>(validFilter.PageNumber, validFilter.PageSize)
            {
                Data = datas
            };

            return rs;
        }
    }
}
