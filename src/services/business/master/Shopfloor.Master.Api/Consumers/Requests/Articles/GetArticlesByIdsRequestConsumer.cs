using AutoMapper;
using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Articles;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetArticlesByIdsRequestConsumer : IConsumer<GetArticlesByIdsRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetArticlesByIdsRequestConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetArticlesByIdsRequest> context)
        {
            Log.Warning($"GetArticlesRequestConsumer: request={context.Message.ToJson()}");

            var articles = await _mediator.Send(new GetArticlesByIdsQuery()
            {
                Ids = context.Message.Ids
            });
            if (articles?.Data == null) await context.RespondAsync(null);
            var response = new GetArticlesByIdsResponse
            {
                Data = articles.Data.Select(x => new GetArticleByIdResponse
                {
                    Id = x.Id,
                    UseForIED = x.UseForIED,
                    OurContact = x.OurContact,
                    PurchaseUOM = x.PurchaseUOM,
                    StoringUOM = x.StoringUOM,
                    ConsumptionUOM = x.ConsumptionUOM,
                    ColorCard = x.ColorCard,
                    SizeWidthRange = x.SizeWidthRange,
                    MinimumQty = x.MinimumQty,
                    MaximumQty = x.MaximumQty,
                    Buyer = x.Buyer,
                    RestrictedItem = x.RestrictedItem,
                    Supplier = x.Supplier,
                    Brand = x.Brand,
                    BuyingPrice = x.BuyingPrice,
                    BuyingCurrencyCode = x.BuyingCurrencyCode,
                    PricePer = x.PricePer,
                    PerSizeCons = x.PerSizeCons,
                    OrderQtyMultiple = x.OrderQtyMultiple,
                    FabricMaterial = x.FabricMaterial,
                    DivisionName = x.DivisionName,
                    Season = x.Season,
                    BuyerStyleRef = x.BuyerStyleRef,
                    Gender = x.Gender,
                    ColorDefinition = x.ColorDefinition,
                    SAM = x.SAM,
                    SellingPrice = x.SellingPrice,
                    SellingPriceCurrency = x.SellingPriceCurrency,
                    BuyerDepartmentName = x.BuyerDepartmentName,
                    HSCode = x.HSCode,
                    StyleType = x.StyleType,
                    Reference = x.Reference,
                    MinimumOrderQty = x.MinimumOrderQty,
                    RequirementMultiple = x.RequirementMultiple,
                    IsActive = x.IsActive,
                    ModelNo = x.ModelNo,
                    MYear = x.MYear,
                    PackingTypeName = x.PackingTypeName,
                    ReOrderLevel = x.ReOrderLevel,
                    StockTypeName = x.StockTypeName,
                    MaterialType = x.MaterialType,
                    Category = x.Category,
                    ArticleCode = x.ArticleCode,
                    ArticleDesc = x.ArticleDesc,
                    ArticleName = x.ArticleName,
                    ProductGroup = x.ProductGroup,
                    ProductSubCategory = x.ProductSubCategory,
                    WFXArticleId = x.WFXArticleId,

                    FlexFieldList = _mapper.Map<List<ArticleFlexField>, List<WfxArticleFlexFieldDto>>(x.FlexFieldList.ToList()),
                    BaseColorList = _mapper.Map<List<ArticleBaseColor>, List<WfxArticleBaseColorDto>>(x.BaseColorList.ToList()),
                    BaseSizeList = _mapper.Map<List<ArticleBaseSize>, List<WfxArticleBaseSizeDto>>(x.BaseSizeList.ToList()),

                }).ToList()
            };
            Log.Information($"GetArticlesByIdsRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}