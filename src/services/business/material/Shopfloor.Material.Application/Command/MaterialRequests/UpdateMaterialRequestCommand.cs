using AutoMapper;

using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Application.Models.FabricCompositions;
using Shopfloor.Material.Application.Models.MaterialRequests;
using Shopfloor.Material.Application.Models.MOQMSQRoudingOptionItems;
using Shopfloor.Material.Application.Models.SupplierWisePurchaseOptions;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class UpdateMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

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

        public decimal BuyingPrice { get; set; }

        public string BuyingCurrencyCode { get; set; }

        public string BuyingCurrencyName { get; set; }

        public string PricePerCode { get; set; }

        public string PricePerName { get; set; }

        public string ColorTypeCode { get; set; }

        public string ColorTypeName { get; set; }

        public string PerSizeConsCode { get; set; }

        public string PerSizeConsName { get; set; }

        public decimal OrderQtyMultiple { get; set; }

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

        public decimal SecondaryUomConversion { get; set; }

        public string StockMovementUomCode { get; set; }

        public string StockMovementUomName { get; set; }

        public decimal StockMovementConversion { get; set; }

        public string CatalogPath { get; set; }

        public string DesignAndPattern { get; set; }

        public string DesignAndPatternName { get; set; }

        public decimal InternalPrice { get; set; }

        public string Finish { get; set; }

        public string HSNCode { get; set; }

        public decimal MinimumOrder { get; set; }

        public decimal MinimumQty { get; set; }

        public decimal MaximumQty { get; set; }

        public decimal MinimumOrderQty { get; set; }

        public string RequirementMultiple { get; set; }

        public string HTSCode { get; set; }

        public decimal Weight { get; set; }

        public string ArticleNameChinese { get; set; }

        public string FabricAndMaterial { get; set; }

        public string PicName { get; set; }

        public ProcessStatus Status { get; set; }

        public Guid? ApproveUserId { get; set; }

        public string ApproveName { get; set; }

        public ICollection<SupplierWisePurchaseOptionModel> SupplierWisePurchaseOptions { get; set; }

        public ICollection<MOQMSQRoudingOptionItemModel> MoqmsqRoudingOptionItems { get; set; }

        public ICollection<FabricCompositionModel> FabricCompositions { get; set; }

        public ICollection<MaterialRequestDynamicColumnModel> DynamicColumns { get; set; }
    }

    public class UpdateMaterialRequestCommandHandler : IRequestHandler<UpdateMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repositoryMaterial;

        private readonly IMOQMSQRoudingOptionItemRepository _repositoryMoqmsqRoudingOptionItem;

        private readonly IFabricCompositionRepository _repositoryFabricComposition;

        private readonly ISupplierWisePurchaseOptionRepository _repositorySupplierWisePurchaseOption;

        private readonly IMapper _mapper;

        public UpdateMaterialRequestCommandHandler(IMaterialRequestRepository repositoryMaterial,
            IMapper mapper,
            IMOQMSQRoudingOptionItemRepository repositoryMoqmsqRoudingOptionItem,
            IFabricCompositionRepository repositoryFabricComposition,
            ISupplierWisePurchaseOptionRepository repositorySupplierWisePurchaseOption)
        {
            _repositoryMaterial = repositoryMaterial;
            _mapper = mapper;
            _repositoryMoqmsqRoudingOptionItem = repositoryMoqmsqRoudingOptionItem;
            _repositoryFabricComposition = repositoryFabricComposition;
            _repositorySupplierWisePurchaseOption = repositorySupplierWisePurchaseOption;
        }

        public async Task<Response<int>> Handle(UpdateMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repositoryMaterial.GetWithIncludeByIdAsync(command.Id);
            if (entity == null)
                throw new ApiException($"MaterialRequest Not Found.");
            var dataMaterialRequest = _mapper.Map<MaterialRequest>(command);
            entity.MaterialTypeCode = dataMaterialRequest.MaterialTypeCode;
            entity.MaterialTypeName = dataMaterialRequest.MaterialTypeName;
            entity.ArticleCode = dataMaterialRequest.ArticleCode;
            entity.ArticleName = dataMaterialRequest.ArticleName;
            entity.PicName = dataMaterialRequest.PicName;
            entity.ArticleDesc = dataMaterialRequest.ArticleDesc;
            entity.BuyingPrice = dataMaterialRequest.BuyingPrice;
            entity.BuyerRef = dataMaterialRequest.BuyerRef;
            entity.SupplierRef = dataMaterialRequest.SupplierRef;
            entity.OrderQtyMultiple = dataMaterialRequest.OrderQtyMultiple;
            entity.ProvisionalStyleRef = dataMaterialRequest.ProvisionalStyleRef;
            entity.SampleRef = dataMaterialRequest.SampleRef;
            entity.ReorderLevel = dataMaterialRequest.ReorderLevel;
            entity.Remarks = dataMaterialRequest.Remarks;
            entity.ContentName = dataMaterialRequest.ContentName;
            entity.SecondaryUomConversion = dataMaterialRequest.SecondaryUomConversion;
            entity.StockMovementConversion = dataMaterialRequest.StockMovementConversion;
            entity.Brand = dataMaterialRequest.Brand;
            entity.BuyerCode = dataMaterialRequest.BuyerCode;
            entity.BuyerDivisionSupplierCode = dataMaterialRequest.BuyerDivisionSupplierCode;
            entity.BuyingCurrencyCode = dataMaterialRequest.BuyingCurrencyCode;
            entity.ColorGroupCode = dataMaterialRequest.ColorGroupCode;
            entity.ColorTypeCode = dataMaterialRequest.ColorTypeCode;
            entity.ConsUomCode = dataMaterialRequest.ConsUomCode;
            entity.ConstructionCode = dataMaterialRequest.ConstructionCode;
            entity.CountCode = dataMaterialRequest.CountCode;
            entity.CropSeasonCode = dataMaterialRequest.CropSeasonCode;
            entity.DivisionCode = dataMaterialRequest.DivisionCode;
            entity.FiberTypeCode = dataMaterialRequest.FiberTypeCode;
            entity.GenderCode = dataMaterialRequest.GenderCode;
            entity.GradeCode = dataMaterialRequest.GradeCode;
            entity.MicronaireCode = dataMaterialRequest.MicronaireCode;
            entity.OriginCode = dataMaterialRequest.OriginCode;
            entity.OurContactCode = dataMaterialRequest.OurContactCode;
            entity.PerSizeConsCode = dataMaterialRequest.PerSizeConsCode;
            entity.PricePerCode = dataMaterialRequest.PricePerCode;
            entity.ProductCatCode = dataMaterialRequest.ProductCatCode;
            entity.ProductGroupCode = dataMaterialRequest.ProductGroupCode;
            entity.ProductSubCatCode = dataMaterialRequest.ProductSubCatCode;
            entity.QualityCode = dataMaterialRequest.QualityCode;
            entity.SeasonCode = dataMaterialRequest.SeasonCode;
            entity.SecondaryUomCode = dataMaterialRequest.SecondaryUomCode;
            entity.StapleCode = dataMaterialRequest.StapleCode;
            entity.SizeGroupCode = dataMaterialRequest.SizeGroupCode;
            entity.StockMovementUomCode = dataMaterialRequest.StockMovementUomCode;
            entity.StoringUomCode = dataMaterialRequest.StoringUomCode;
            entity.StrengthCode = dataMaterialRequest.StrengthCode;
            entity.SupplierCode = dataMaterialRequest.SupplierCode;
            entity.ThemeCode = dataMaterialRequest.ThemeCode;
            entity.UomCode = dataMaterialRequest.UomCode;
            entity.BuyerName = dataMaterialRequest.BuyerName;
            entity.BuyerDivisionSupplierName = dataMaterialRequest.BuyerDivisionSupplierName;
            entity.BuyingCurrencyName = dataMaterialRequest.BuyingCurrencyName;
            entity.ColorGroupName = dataMaterialRequest.ColorGroupName;
            entity.ColorTypeName = dataMaterialRequest.ColorTypeName;
            entity.ConsUomName = dataMaterialRequest.ConsUomName;
            entity.ConstructionName = dataMaterialRequest.ConstructionName;
            entity.CountName = dataMaterialRequest.CountName;
            entity.CropSeasonName = dataMaterialRequest.CropSeasonName;
            entity.DivisionName = dataMaterialRequest.DivisionName;
            entity.FiberTypeName = dataMaterialRequest.FiberTypeName;
            entity.GenderName = dataMaterialRequest.GenderName;
            entity.GradeName = dataMaterialRequest.GradeName;
            entity.MicronaireName = dataMaterialRequest.MicronaireName;
            entity.OriginName = dataMaterialRequest.OriginName;
            entity.OurContactName = dataMaterialRequest.OurContactName;
            entity.PerSizeConsName = dataMaterialRequest.PerSizeConsName;
            entity.PricePerName = dataMaterialRequest.PricePerName;
            entity.ProductCatName = dataMaterialRequest.ProductCatName;
            entity.ProductGroupName = dataMaterialRequest.ProductGroupName;
            entity.ProductSubCatName = dataMaterialRequest.ProductSubCatName;
            entity.QualityName = dataMaterialRequest.QualityName;
            entity.SeasonName = dataMaterialRequest.SeasonName;
            entity.StapleName = dataMaterialRequest.StapleName;
            entity.SizeGroupName = dataMaterialRequest.SizeGroupName;
            entity.StockMovementUomName = dataMaterialRequest.StockMovementUomName;
            entity.StoringUomName = dataMaterialRequest.StoringUomName;
            entity.StrengthName = dataMaterialRequest.StrengthName;
            entity.SupplierName = dataMaterialRequest.SupplierName;
            entity.ThemeName = dataMaterialRequest.ThemeName;
            entity.UomName = dataMaterialRequest.UomName;
            entity.MinimumOrder = dataMaterialRequest.MinimumOrder;
            entity.CatalogPath = dataMaterialRequest.CatalogPath;
            entity.DesignAndPattern = dataMaterialRequest.DesignAndPattern;
            entity.DesignAndPatternName = dataMaterialRequest.DesignAndPatternName;
            entity.InternalPrice = dataMaterialRequest.InternalPrice;
            entity.Finish = dataMaterialRequest.Finish;
            entity.HSNCode = dataMaterialRequest.HSNCode;
            entity.MinimumQty = dataMaterialRequest.MinimumQty;
            entity.MaximumQty = dataMaterialRequest.MaximumQty;
            entity.MinimumOrderQty = dataMaterialRequest.MinimumOrderQty;
            entity.RequirementMultiple = dataMaterialRequest.RequirementMultiple;
            entity.HTSCode = dataMaterialRequest.HTSCode;
            entity.Weight = dataMaterialRequest.Weight;
            entity.FabricAndMaterial = dataMaterialRequest.FabricAndMaterial;
            entity.ArticleNameChinese = dataMaterialRequest.ArticleNameChinese;

            #region MoqmsqRoudingOptionItems

            // lay ra Entities can add them
            var addEntitiesMoqmsqRoudingOptionItems =
                dataMaterialRequest.MoqmsqRoudingOptionItems.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesMoqmsqRoudingOptionItems =
                dataMaterialRequest.MoqmsqRoudingOptionItems.Where(x => x.Id != 0).ToList();

            // lấy ra Entities cần remove
            var deleteEntitiesMoqmsqRoudingOptionItems =
                entity.MoqmsqRoudingOptionItems
                    .Where(x => !updateEntitiesMoqmsqRoudingOptionItems.Any() || updateEntitiesMoqmsqRoudingOptionItems.Any(y => y.Id != x.Id))
                    .ToList();

            #endregion MoqmsqRoudingOptionItems

            #region SupplierWisePurchaseOptions

            // lay ra Entities can add them
            var addEntitiesSupplierWisePurchaseOptions =
                dataMaterialRequest.SupplierWisePurchaseOptions.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesSupplierWisePurchaseOptions =
                dataMaterialRequest.SupplierWisePurchaseOptions.Where(x => x.Id != 0).ToList();

            // lấy ra Entities cần remove
            var deleteEntitiesSupplierWisePurchaseOptions =
                entity.SupplierWisePurchaseOptions.Where(x => !updateEntitiesSupplierWisePurchaseOptions.Any() || updateEntitiesSupplierWisePurchaseOptions.Any(y => y.Id != x.Id)).ToList();

            #endregion SupplierWisePurchaseOptions

            #region FabricCompositions

            // lay ra Entities can add them
            var addEntitiesFabricCompositions =
                dataMaterialRequest.FabricCompositions.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesFabricCompositions =
                dataMaterialRequest.FabricCompositions.Where(x => x.Id != 0).ToList();

            // lấy ra Entities cần remove
            var deleteEntitiesFabricCompositions =
                entity.FabricCompositions.Where(x => !updateEntitiesFabricCompositions.Any() || updateEntitiesFabricCompositions.Any(y => y.Id != x.Id)).ToList();

            #endregion FabricCompositions

            #region DynamicColumns

            // lay ra Entities can add them
            var addEntitiesMaterialRequestDynamicColumns =
                dataMaterialRequest.DynamicColumns.Where(x => x.Id == 0).ToList();

            // lấy ra Entities cần update
            var updateEntitiesMaterialRequestDynamicColumns =
                dataMaterialRequest.DynamicColumns.Where(x => x.Id != 0).ToList();

            // lấy ra Entities cần remove
            var deleteEntitiesMaterialRequestDynamicColumns =
                entity.DynamicColumns
                    .Where(x => !updateEntitiesMaterialRequestDynamicColumns.Any() || updateEntitiesMaterialRequestDynamicColumns.Any(y => y.Id != x.Id))
                    .ToList();

            #endregion DynamicColumns

            entity.MoqmsqRoudingOptionItems = updateEntitiesMoqmsqRoudingOptionItems;
            entity.SupplierWisePurchaseOptions = updateEntitiesSupplierWisePurchaseOptions;
            entity.FabricCompositions = updateEntitiesFabricCompositions;
            entity.DynamicColumns = updateEntitiesMaterialRequestDynamicColumns;

            await _repositoryMaterial.UpdateMaterialRequestAsync(entity, new BaseListCreateDeleteEntity<MOQMSQRoudingOptionItem>
            {
                LstDataAdd = addEntitiesMoqmsqRoudingOptionItems,
                LstDataDelete = deleteEntitiesMoqmsqRoudingOptionItems
            }, new BaseListCreateDeleteEntity<SupplierWisePurchaseOption>
            {
                LstDataAdd = addEntitiesSupplierWisePurchaseOptions,
                LstDataDelete = deleteEntitiesSupplierWisePurchaseOptions
            },
            new BaseListCreateDeleteEntity<FabricComposition>
            {
                LstDataAdd = addEntitiesFabricCompositions,
                LstDataDelete = deleteEntitiesFabricCompositions
            },
            new BaseListCreateDeleteEntity<MaterialRequestDynamicColumn>
            {
                LstDataAdd = addEntitiesMaterialRequestDynamicColumns,
                LstDataDelete = deleteEntitiesMaterialRequestDynamicColumns
            });

            return new Response<int>(command.Id);
        }
    }
}