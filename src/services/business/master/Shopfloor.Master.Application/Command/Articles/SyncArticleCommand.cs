using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Articles
{
    public class SyncArticleCommand : IRequest<Response<bool>>
    {
        public string Category { get; set; }
        public List<WfxArticleDto> Data { get; set; }
    }
    public class SyncArticleCommandHandler : IRequestHandler<SyncArticleCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        public SyncArticleCommandHandler(IMapper mapper,
            IArticleRepository repository
            )
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(SyncArticleCommand command, CancellationToken cancellationToken)
        {
            if (command.Data == null || command.Data.Count == 0) return new Response<bool>(true);
            var entities = await _repository.GetAllArticlesForSycnWFXAsync(command.Category);
            var newEntities = GetNewEntities(entities.ToList(), command.Data);
            var listDeleteArticleBaseColor = new List<ArticleBaseColor>();
            var listDeleteArticleBaseSize = new List<ArticleBaseSize>();
            var listDeleteArticleFlexField = new List<ArticleFlexField>();
            var updateEntities = GetUpdateEntities(entities.ToList(), command.Data, listDeleteArticleBaseColor, listDeleteArticleBaseSize, listDeleteArticleFlexField);

            if (newEntities.Count > 0) { await _repository.AddRangeAsync(newEntities); }
            if (updateEntities.Count > 0)
            {
                await _repository.UpdateArticlesAsync(updateEntities, listDeleteArticleBaseColor,
                listDeleteArticleBaseSize, listDeleteArticleFlexField);
            }

            return new Response<bool>(true);
        }

        private List<Article> GetNewEntities(List<Article> entities, List<WfxArticleDto> input)
        {
            return input.Where(x => entities.Count == 0 || !entities.Any(r => r.WFXArticleId == x.ArticleID))
                .Select(x => PrepareArticle(x)).ToList();
        }

        private List<Article> GetUpdateEntities(List<Article> entities,
            List<WfxArticleDto> input,
              List<ArticleBaseColor> articleBaseColors,
              List<ArticleBaseSize> articleBaseSizes,
              List<ArticleFlexField> articleFlexFields
            )
        {
            var changeds = entities.Where(x => input.Any(r => r.ArticleID == x.WFXArticleId && IsChanged(x, r)));
            var entites = new List<Article>();
            foreach (var r in changeds)
            {
                articleBaseColors.AddRange(r.BaseColorList);
                articleFlexFields.AddRange(r.FlexFieldList);
                articleBaseSizes.AddRange(r.BaseSizeList);

                var ent = input.FirstOrDefault(x => x.ArticleID == r.WFXArticleId);
                var entityChanged = PrepareArticle(ent, r);
                entites.Add(r);
            }
            return entites;
        }
        Article PrepareArticle(WfxArticleDto r, Article entity = null)
        {
            if (entity == null)
            {
                entity = new Article
                {
                    ArticleCode = r.ArticleCode,
                    ArticleDesc = r.ArticleDesc,
                    ArticleName = r.ArticleName,
                    BaseColorList = r.BaseColorList?.Select(x => new ArticleBaseColor
                    {
                        ColorCode = x.ColorCode,
                        ColorName = x.ColorName,
                        IsActive = true,
                        WFXColorId = x.ColorID
                    }).ToList(),
                    IsActive = true,
                    BaseSizeList = r.BaseSizeList?.Select(x => new ArticleBaseSize
                    {
                        IsActive = true,
                        SizeCode = x.SizeCode,
                        SizeName = x.SizeName,
                    }).ToList(),
                    Brand = r.Brand,
                    Category = r.Category,
                    DivisionName = r.DivisionName,
                    FabricMaterial = r.FabricMaterial,
                    FlexFieldList = r.FlexFieldList?.Select(x => new ArticleFlexField
                    {
                        AttributeName = x.AttributeName,
                        AttributeValue = x.AttributeValue
                    }).ToList(),
                    Buyer = r.Buyer,
                    BuyerDepartmentName = r.BuyerDepartmentName,
                    BuyerStyleRef = r.BuyerStyleRef,
                    BuyingCurrencyCode = r.BuyingCurrencyCode,
                    BuyingPrice = r.BuyingPrice,
                    ColorCard = r.ColorCard,
                    ColorDefinition = r.ColorDefinition,
                    ConsumptionUOM = r.ConsumptionUOM,
                    Gender = r.Gender,
                    HSCode = r.HSCode,
                    MaterialType = r.MaterialType,
                    MaximumQty = r.MaximumQty,
                    MinimumOrderQty = r.MinimumOrderQty,
                    MinimumQty = r.MinimumQty,
                    ModelNo = r.ModelNo,
                    MYear = r.MYear,
                    OrderQtyMultiple = r.OrderQtyMultiple,
                    OurContact = r.OurContact,
                    PackingTypeName = r.PackingTypeName,
                    PerSizeCons = r.PerSizeCons,
                    PricePer = r.PricePer,
                    ProductGroup = r.ProductGroup,
                    ProductSubCategory = r.ProductSubCategory,
                    PurchaseUOM = r.PurchaseUOM,
                    Reference = r.Reference,
                    ReOrderLevel = r.ReOrderLevel,
                    RestrictedItem = r.RestrictedItem,
                    SAM = r.SAM,
                    RequirementMultiple = r.RequirementMultiple,
                    Season = r.Season,
                    SellingPrice = r.SellingPrice,
                    SellingPriceCurrency = r.SellingPriceCurrency,
                    SizeWidthRange = r.SizeWidthRange,
                    StockTypeName = r.StockTypeName,
                    StoringUOM = r.StoringUOM,
                    StyleType = r.StyleType,
                    Supplier = r.Supplier,
                    UseForIED = true,
                    WFXArticleId = r.ArticleID
                };
            }
            else
            {
                entity.ArticleCode = r.ArticleCode;
                entity.ArticleDesc = r.ArticleDesc;
                entity.ArticleName = r.ArticleName;
                entity.IsActive = true;
                entity.Brand = r.Brand;
                entity.Category = r.Category;
                entity.DivisionName = r.DivisionName;
                entity.FabricMaterial = r.FabricMaterial;
                entity.Buyer = r.Buyer;
                entity.BuyerDepartmentName = r.BuyerDepartmentName;
                entity.BuyerStyleRef = r.BuyerStyleRef;
                entity.BuyingCurrencyCode = r.BuyingCurrencyCode;
                entity.BuyingPrice = r.BuyingPrice;
                entity.ColorCard = r.ColorCard;
                entity.ColorDefinition = r.ColorDefinition;
                entity.ConsumptionUOM = r.ConsumptionUOM;
                entity.Gender = r.Gender;
                entity.HSCode = r.HSCode;
                entity.MaterialType = r.MaterialType;
                entity.MaximumQty = r.MaximumQty;
                entity.MinimumOrderQty = r.MinimumOrderQty;
                entity.MinimumQty = r.MinimumQty;
                entity.ModelNo = r.ModelNo;
                entity.MYear = r.MYear;
                entity.OrderQtyMultiple = r.OrderQtyMultiple;
                entity.OurContact = r.OurContact;
                entity.PackingTypeName = r.PackingTypeName;
                entity.PerSizeCons = r.PerSizeCons;
                entity.PricePer = r.PricePer;
                entity.ProductGroup = r.ProductGroup;
                entity.ProductSubCategory = r.ProductSubCategory;
                entity.PurchaseUOM = r.PurchaseUOM;
                entity.Reference = r.Reference;
                entity.ReOrderLevel = r.ReOrderLevel;
                entity.RestrictedItem = r.RestrictedItem;
                entity.SAM = r.SAM;
                entity.RequirementMultiple = r.RequirementMultiple;
                entity.Season = r.Season;
                entity.SellingPrice = r.SellingPrice;
                entity.SellingPriceCurrency = r.SellingPriceCurrency;
                entity.SizeWidthRange = r.SizeWidthRange;
                entity.StockTypeName = r.StockTypeName;
                entity.StoringUOM = r.StoringUOM;
                entity.StyleType = r.StyleType;
                entity.Supplier = r.Supplier;
                entity.UseForIED = true;
                entity.WFXArticleId = r.ArticleID;
                entity.BaseColorList = r.BaseColorList?.Select(x => new ArticleBaseColor
                {
                    ColorCode = x.ColorCode,
                    ColorName = x.ColorName,
                    IsActive = true,
                    WFXColorId = x.ColorID,
                    ArticleId = entity.Id
                }).ToList();
                entity.BaseSizeList = r.BaseSizeList?.Select(x => new ArticleBaseSize
                {
                    IsActive = true,
                    SizeCode = x.SizeCode,
                    SizeName = x.SizeName,
                    ArticleId = entity.Id
                }).ToList();
                entity.FlexFieldList = r.FlexFieldList?.Select(x => new ArticleFlexField
                {
                    AttributeName = x.AttributeName,
                    AttributeValue = x.AttributeValue,
                    ArticleId = entity.Id
                }).ToList();
            }
            return entity;
        }
        bool IsChanged(Article article, WfxArticleDto wfxArticle)
        {
            var properties = new string[] {
              nameof(Article.Category),
              nameof(Article.MaterialType),
              nameof(Article.ArticleCode),
              nameof(Article.ArticleName),
              nameof(Article.ArticleDesc),
              nameof(Article.ProductGroup),
              nameof(Article.ProductSubCategory),
              nameof(Article.FabricMaterial),
              nameof(Article.OurContact),
              nameof(Article.PurchaseUOM),
              nameof(Article.StoringUOM),
              nameof(Article.DivisionName),
              nameof(Article.ConsumptionUOM),
              nameof(Article.ColorCard),
              nameof(Article.SizeWidthRange),
              nameof(Article.MinimumQty),
              nameof(Article.MaximumQty),
              nameof(Article.Buyer),
              nameof(Article.RestrictedItem),
              nameof(Article.Supplier),
              nameof(Article.Brand),
              nameof(Article.BuyingPrice),
              nameof(Article.BuyingCurrencyCode),
              nameof(Article.PricePer),
              nameof(Article.PerSizeCons),
              nameof(Article.OrderQtyMultiple),
              nameof(Article.Season),
              nameof(Article.BuyerStyleRef),
              nameof(Article.Gender),
              nameof(Article.ColorDefinition),
              nameof(Article.SAM),
              nameof(Article.SellingPrice),
              nameof(Article.SellingPriceCurrency),
              nameof(Article.BuyerDepartmentName),
              nameof(Article.HSCode),
              nameof(Article.StyleType),
              nameof(Article.Reference),
              nameof(Article.ModelNo),
              nameof(Article.MYear),
              nameof(Article.PackingTypeName),
              nameof(Article.StockTypeName),
              nameof(Article.ReOrderLevel),
              nameof(Article.MinimumOrderQty),
              nameof(Article.RequirementMultiple),
            };
            foreach (var pt in properties)
            {
                var val = article.GetType().GetProperty(pt)?.GetValue(article);
                var valCompare = wfxArticle.GetType().GetProperty(pt)?.GetValue(wfxArticle);
                if (val == null && valCompare == null)
                    continue;
                if ((val == null && valCompare != null) || (val != null && valCompare == null))
                    return true;
                if (val?.Equals(valCompare) != true)
                    return true;
            }
            if (wfxArticle.BaseColorList.Count() != article.BaseColorList.Count())
                return true;
            if (wfxArticle.BaseSizeList.Count() != article.BaseSizeList.Count())
                return true;
            if (wfxArticle.FlexFieldList.Count() != article.FlexFieldList.Count())
                return true;

            if (wfxArticle.BaseColorList.Any(x => !article.BaseColorList.Any(v => v.WFXColorId == x.ColorID && (v.ColorName == x.ColorName && v.ColorCode == x.ColorCode))))
                return true;
            if (wfxArticle.BaseSizeList.Any(x => !article.BaseSizeList.Any(v => v.SizeName == x.SizeName && v.SizeCode == x.SizeCode)))
                return true;
            if (wfxArticle.FlexFieldList.Any(x => !article.FlexFieldList.Any(v => v.AttributeName == x.AttributeName && x.AttributeValue != null && v.AttributeValue?.Equals(x.AttributeValue) == true)))
                return true;
            return false;
        }
    }
}
