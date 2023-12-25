using Microsoft.AspNetCore.Mvc;
using Shopfloor.Master.Application.Parameters.Articles;
using Shopfloor.Master.Application.Query.Articles;

namespace Shopfloor.Master.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ArticleController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ArticleParameter filter)
        {
            return Ok(await Mediator.Send(new GetArticlesQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,

                UseForIED = filter.UseForIED,
                OurContact = filter.OurContact,
                PurchaseUOM = filter.PurchaseUOM,
                StoringUOM = filter.StoringUOM,
                ConsumptionUOM = filter.ConsumptionUOM,
                ColorCard = filter.ColorCard,
                SizeWidthRange = filter.SizeWidthRange,
                MinimumQty = filter.MinimumQty,
                MaximumQty = filter.MaximumQty,
                Buyer = filter.Buyer,
                RestrictedItem = filter.RestrictedItem,
                Supplier = filter.Supplier,
                Brand = filter.Brand,
                BuyingPrice = filter.BuyingPrice,
                BuyingCurrencyCode = filter.BuyingCurrencyCode,
                PricePer = filter.PricePer,
                PerSizeCons = filter.PerSizeCons,
                OrderQtyMultiple = filter.OrderQtyMultiple,
                FabricMaterial = filter.FabricMaterial,
                DivisionName = filter.DivisionName,
                Season = filter.Season,
                BuyerStyleRef = filter.BuyerStyleRef,
                Gender = filter.Gender,
                ColorDefinition = filter.ColorDefinition,
                SAM = filter.SAM,
                SellingPrice = filter.SellingPrice,
                SellingPriceCurrency = filter.SellingPriceCurrency,
                BuyerDepartmentName = filter.BuyerDepartmentName,
                HSCode = filter.HSCode,
                StyleType = filter.StyleType,
                Reference = filter.Reference,
                MinimumOrderQty = filter.MinimumOrderQty,
                RequirementMultiple = filter.RequirementMultiple,
                OrderBy = filter.OrderBy,
                SearchTerm = filter.SearchTerm,
                IsActive = filter.IsActive,
                BypassCache = filter.BypassCache,
                SlidingExpiration = filter.SlidingExpiration,
                ArticleCode = filter.ArticleCode,
                ArticleDesc = filter.ArticleDesc,
                ArticleName = filter.ArticleName,
                Category = filter.Category,
                MaterialType = filter.MaterialType,
                ModelNo = filter.ModelNo,
                MYear = filter.MYear,
                PackingTypeName = filter.PackingTypeName,
                ProductGroup = filter.ProductGroup,
                ProductSubCategory = filter.ProductSubCategory,
                ReOrderLevel = filter.ReOrderLevel,
                StockTypeName = filter.StockTypeName,
                WFXArticleId = filter.WFXArticleId
            }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetArticleQuery { Id = id }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("wfx/{wfxId}")]
        public async Task<IActionResult> GetByWFXId(int wfxId)
        {
            return Ok(await Mediator.Send(new GetArticleByWFXIdQuery { WFXArticleId = wfxId }));
        }

        // GET api/v1/<controller>/5
        [HttpGet("code")]
        public async Task<IActionResult> GetByCode([FromQuery] string code)
        {
            return Ok(await Mediator.Send(new GetArticleByCodeQuery { Code = code }));
        }
    }
}