using MassTransit;
using MediatR;
using Serilog;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Query.Articles;

namespace Shopfloor.Master.Api.Consumers.Requests
{
    public class GetArticleByIdRequestConsumer : IConsumer<GetArticleByIdRequest>
    {
        #region Initialization

        private readonly IMediator _mediator;

        public GetArticleByIdRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public async Task Consume(ConsumeContext<GetArticleByIdRequest> context)
        {
            Log.Warning($"GetArticleByIdRequestConsumer: request={context.Message.ToJson()}");

            var articles = await _mediator.Send(new GetArticleQuery() { Id = context.Message.Id });
            if (articles?.Data == null) await context.RespondAsync(null);
            var response = new GetArticleByIdResponse
            {
                Id = articles.Data.Id,
                ArticleCode = articles.Data.ArticleCode,
                ArticleName = articles.Data.ArticleName,
                Category = articles.Data.Category,
                MaterialType = articles.Data.MaterialType,
                ProductGroup = articles.Data.ProductGroup,
                ProductSubCategory = articles.Data.ProductSubCategory,
                UseForIED = articles.Data.UseForIED,
                WFXArticleId = articles.Data.WFXArticleId,
                ArticleDesc = articles.Data.ArticleDesc,
                OurContact = articles.Data.OurContact,
                PurchaseUOM = articles.Data.PurchaseUOM,
                StoringUOM = articles.Data.StoringUOM,
                ConsumptionUOM = articles.Data.ConsumptionUOM,
                ColorCard = articles.Data.ColorCard,
                SizeWidthRange = articles.Data.SizeWidthRange,
                MinimumQty = articles.Data.MinimumQty,
                MaximumQty = articles.Data.MaximumQty,
                Buyer = articles.Data.Buyer,
                RestrictedItem = articles.Data.RestrictedItem,
                Supplier = articles.Data.Supplier,
                Brand = articles.Data.Brand,
                BuyingPrice = articles.Data.BuyingPrice,
                BuyingCurrencyCode = articles.Data.BuyingCurrencyCode,
                PricePer = articles.Data.PricePer,
                PerSizeCons = articles.Data.PerSizeCons,
                OrderQtyMultiple = articles.Data.OrderQtyMultiple,
                FabricMaterial = articles.Data.FabricMaterial,
                DivisionName = articles.Data.DivisionName,
                Season = articles.Data.Season,
                BuyerStyleRef = articles.Data.BuyerStyleRef,
                Gender = articles.Data.Gender,
                ColorDefinition = articles.Data.ColorDefinition,
                SAM = articles.Data.SAM,
                SellingPrice = articles.Data.SellingPrice,
                SellingPriceCurrency = articles.Data.SellingPriceCurrency,
                BuyerDepartmentName = articles.Data.BuyerDepartmentName,
                HSCode = articles.Data.HSCode,
                StyleType = articles.Data.StyleType,
                Reference = articles.Data.Reference,
                ModelNo = articles.Data.ModelNo,
                MYear = articles.Data.MYear,
                PackingTypeName = articles.Data.PackingTypeName,
                StockTypeName = articles.Data.StockTypeName,
                ReOrderLevel = articles.Data.ReOrderLevel,
                MinimumOrderQty = articles.Data.MinimumOrderQty,
                RequirementMultiple = articles.Data.RequirementMultiple,
                IsActive = articles.Data.IsActive,
                ServiceCode = articles.Data.ServiceCode,
                ServiceName = articles.Data.ServiceName
            };
            Log.Information($"GetArticleByIdRequestConsumer: response={response}");
            await context.RespondAsync(response);
        }
    }
}