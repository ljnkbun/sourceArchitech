using AutoMapper;

using MediatR;

using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.MaterialRequests;
using Shopfloor.Material.Application.Parameters.MaterialRequests;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.MaterialRequests
{
    public class GetMaterialRequestsQuery : IRequest<PagedResponse<IReadOnlyList<MaterialRequestModel>>>, ICacheableMediatrQuery
    {
        public string RequestNo { get; set; }
        public string HSCode { get; set; }

        public string ProductCatCode { get; set; }

        public string ProductCatName { get; set; }

        public string MaterialTypeCode { get; set; }

        public string MaterialTypeName { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string ArticleDesc { get; set; }

        public string ProductGroupCode { get; set; }

        public string ProductGroupName { get; set; }

        public string ProductSubCatCode { get; set; }

        public string ProductSubCatName { get; set; }

        public string ThemeCode { get; set; }

        public string ThemeName { get; set; }

        public string OurContactCode { get; set; }

        public string OurContactName { get; set; }

        public string UomCode { get; set; }

        public string UomName { get; set; }

        public string StoringUomCode { get; set; }

        public string StoringUomName { get; set; }

        public string ConsUomCode { get; set; }

        public string ConsUomName { get; set; }

        public string SeasonCode { get; set; }

        public string SeasonName { get; set; }

        public string DivisionCode { get; set; }

        public string DivisionName { get; set; }

        public string ColorGroupCode { get; set; }

        public string ColorGroupName { get; set; }

        public string SizeGroupCode { get; set; }

        public string SizeGroupName { get; set; }

        public string BuyerCode { get; set; }

        public string BuyerName { get; set; }

        public string BuyerRef { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; }

        public string SupplierRef { get; set; }

        public string GenderCode { get; set; }

        public string GenderName { get; set; }

        public string Brand { get; set; }

        public decimal? BuyingPrice { get; set; }

        public string BuyingCurrencyCode { get; set; }

        public string BuyingCurrencyName { get; set; }

        public string PricePerCode { get; set; }

        public string PricePerName { get; set; }

        public string ColorTypeCode { get; set; }

        public string ColorTypeName { get; set; }

        public string PerSizeConsCode { get; set; }

        public string PerSizeConsName { get; set; }

        public decimal? OrderQtyMultiple { get; set; }

        public string QualityCode { get; set; }

        public string QualityName { get; set; }

        public string ProvisionalStyleRef { get; set; }

        public string BuyerDivisionSupplierCode { get; set; }

        public string BuyerDivisionSupplierName { get; set; }

        public string SampleRef { get; set; }

        public string ReorderLevel { get; set; }

        public string FiberTypeCode { get; set; }

        public string FiberTypeName { get; set; }

        public string GradeCode { get; set; }

        public string GradeName { get; set; }

        public string MicronaireCode { get; set; }

        public string MicronaireName { get; set; }

        public string StrengthCode { get; set; }

        public string StrengthName { get; set; }

        public string StapleCode { get; set; }

        public string StapleName { get; set; }

        public string CropSeasonCode { get; set; }

        public string CropSeasonName { get; set; }

        public string OriginCode { get; set; }

        public string OriginName { get; set; }

        public string Remarks { get; set; }

        public string CountCode { get; set; }

        public string CountName { get; set; }

        public string ConstructionCode { get; set; }

        public string ConstructionName { get; set; }

        public string ContentName { get; set; }

        public string SecondaryUomCode { get; set; }

        public string SecondaryUomName { get; set; }

        public decimal? SecondaryUomConversion { get; set; }

        public string StockMovementUomCode { get; set; }

        public string StockMovementUomName { get; set; }

        public decimal? StockMovementConversion { get; set; }

        public string CatalogPath { get; set; }

        public string DesignAndPattern { get; set; }

        public string DesignAndPatternName { get; set; }

        public decimal? InternalPrice { get; set; }

        public string Finish { get; set; }

        public string HSNCode { get; set; }

        public decimal? MinimumOrder { get; set; }

        public decimal? MinimumQty { get; set; }

        public decimal? MaximumQty { get; set; }

        public decimal? MinimumOrderQty { get; set; }

        public string RequirementMultiple { get; set; }

        public string HTSCode { get; set; }

        public decimal? Weight { get; set; }

        public string ArticleNameChinese { get; set; }

        public string FabricAndMaterial { get; set; }

        public string PicName { get; set; }

        public ProcessStatus? Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public string ReasonReject { get; set; }

        public DateTime? CreatedFrom { get; set; }

        public DateTime? CreatedTo { get; set; }

        #region Default properties

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string SearchTerm { get; set; }

        public string OrderBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedUserId { get; set; }

        public Guid? ModifiedUserId { get; set; }

        public bool? IsActive { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"MaterialRequests";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Default properties
    }

    public class GetMaterialRequestsQueryHandler : IRequestHandler<GetMaterialRequestsQuery, PagedResponse<IReadOnlyList<MaterialRequestModel>>>
    {
        private readonly IMapper _mapper;

        private readonly IMaterialRequestRepository _repository;

        public GetMaterialRequestsQueryHandler(IMapper mapper,
            IMaterialRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<MaterialRequestModel>>> Handle(GetMaterialRequestsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<MaterialRequestParameter>(request);
            return await _repository.GetMaterialPagedReponseAsync<MaterialRequestParameter, MaterialRequestModel>(validFilter, request.CreatedFrom, request.CreatedTo);
        }
    }
}