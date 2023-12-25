using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Articles;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetArticlesRequestConsumer : IConsumer<GetArticlesRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetArticlesRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetArticlesRequest> context)
        {
            Log.Warning($"GetArticlesRequestConsumer: request={context.Message.ToJson()}");

            var articles = await _mediator.Send(new GetArticlesQuery()
            {
                PageSize = context.Message.PageSize,
                PageNumber = context.Message.PageNumber,
                CreatedDate = context.Message.CreatedDate,
                ModifiedDate = context.Message.ModifiedDate,
                CreatedUserId = context.Message.CreatedUserId,
                ModifiedUserId = context.Message.ModifiedUserId,
                ArticleCode = context.Message.ArticleCode,
                ArticleName = context.Message.ArticleName,
                ProductSubCategory = context.Message.ProductSubCategory,
                UseForIED = context.Message.UseForIED,
                OurContact = context.Message.OurContact,
                PurchaseUOM = context.Message.PurchaseUOM,
                StoringUOM = context.Message.StoringUOM,
                ConsumptionUOM = context.Message.ConsumptionUOM,
                ColorCard = context.Message.ColorCard,
                SizeWidthRange = context.Message.SizeWidthRange,
                MinimumQty = context.Message.MinimumQty,
                MaximumQty = context.Message.MaximumQty,
                Buyer = context.Message.Buyer,
                RestrictedItem = context.Message.RestrictedItem,
                Supplier = context.Message.Supplier,
                Brand = context.Message.Brand,
                BuyingPrice = context.Message.BuyingPrice,
                BuyingCurrencyCode = context.Message.BuyingCurrencyCode,
                PricePer = context.Message.PricePer,
                PerSizeCons = context.Message.PerSizeCons,
                OrderQtyMultiple = context.Message.OrderQtyMultiple,
                FabricMaterial = context.Message.FabricMaterial,
                DivisionName = context.Message.DivisionName,
                Season = context.Message.Season,
                BuyerStyleRef = context.Message.BuyerStyleRef,
                Gender = context.Message.Gender,
                ColorDefinition = context.Message.ColorDefinition,
                SAM = context.Message.SAM,
                SellingPrice = context.Message.SellingPrice,
                SellingPriceCurrency = context.Message.SellingPriceCurrency,
                BuyerDepartmentName = context.Message.BuyerDepartmentName,
                HSCode = context.Message.HSCode,
                StyleType = context.Message.StyleType,
                Reference = context.Message.Reference,
                MinimumOrderQty = context.Message.MinimumOrderQty,
                RequirementMultiple = context.Message.RequirementMultiple,
                IsActive = context.Message.IsActive,
                BypassCache = context.Message.BypassCache,
                SlidingExpiration = context.Message.SlidingExpiration,
                ArticleDesc = context.Message.ArticleDesc,
                WFXArticleId = context.Message.WFXArticleId,
                StockTypeName = context.Message.StockTypeName,
                ReOrderLevel = context.Message.ReOrderLevel,
                ProductGroup = context.Message.ProductGroup,
                PackingTypeName = context.Message.PackingTypeName,
                MYear = context.Message.MYear,
                Category = context.Message.Category,
                MaterialType = context.Message.MaterialType,
                ModelNo = context.Message.ModelNo
            });
            if (articles?.Data == null) await context.RespondAsync(null);
            var response = new GetArticlesResponse
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
                }).ToList()
            };
            Log.Information($"GetArticlesRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}