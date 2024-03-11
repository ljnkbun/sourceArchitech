using AutoMapper;
using MediatR;
using NPOI.OpenXmlFormats.Dml;
using Shopfloor.Core.Extensions.Objects;
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
    public class UpdateMaterialRequestCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
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

    public class UpdateMaterialRequestCommandHandler : IRequestHandler<UpdateMaterialRequestCommand, Response<bool>>
    {
        private readonly IMaterialRequestRepository _repositoryMaterial;

        private readonly IMapper _mapper;

        public UpdateMaterialRequestCommandHandler(IMaterialRequestRepository repositoryMaterial,
            IMapper mapper)
        {
            _repositoryMaterial = repositoryMaterial;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repositoryMaterial.GetWithIncludeByIdAsync(command.Id);
            if (entity == null)
                return new($"MaterialRequest Not Found.");
            var ignores = new[]
            {
                nameof(MaterialRequest.Id),
                nameof(MaterialRequest.CreatedDate),
                nameof(MaterialRequest.CreatedUserId),
                nameof(MaterialRequest.SupplierWisePurchaseOptions),
                nameof(MaterialRequest.MoqmsqRoudingOptionItems),
                nameof(MaterialRequest.FabricCompositions),
                nameof(MaterialRequest.DynamicColumns),
            };
            command.TransferProperties(entity, ignores);
            var dbSupplierWisePurchaseOptions = entity.SupplierWisePurchaseOptions;
            var dbMoqmsqRoudingOptionItems = entity.MoqmsqRoudingOptionItems;
            var dbFabricCompositions = entity.FabricCompositions;
            var dbMaterialRequestDynamicColumns = entity.DynamicColumns;
            entity.SupplierWisePurchaseOptions = null;
            entity.MoqmsqRoudingOptionItems = null;
            entity.FabricCompositions = null;
            entity.DynamicColumns = null;

            #region SupplierWisePurchaseOption
            IEnumerable<SupplierWisePurchaseOption> dbSupplierWisePurchaseOptionModifieds = new List<SupplierWisePurchaseOption>();
            IEnumerable<SupplierWisePurchaseOption> newSupplierWisePurchaseOptionAddeds = new List<SupplierWisePurchaseOption>();
            IEnumerable<SupplierWisePurchaseOption> dbSupplierWisePurchaseOptionDeletes = new List<SupplierWisePurchaseOption>();
            if (command.SupplierWisePurchaseOptions != null)
            {
                dbSupplierWisePurchaseOptionModifieds = dbSupplierWisePurchaseOptions.Where(x => command.SupplierWisePurchaseOptions.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.SupplierWisePurchaseOptions.First(c => c.Id == x.Id), x));

                newSupplierWisePurchaseOptionAddeds = command.SupplierWisePurchaseOptions.Where(x => x.Id == 0)
                    .Select(x =>
                    {
                        var test = _mapper.Map<SupplierWisePurchaseOption>(x);
                        return test;
                    });

                dbSupplierWisePurchaseOptionDeletes =
                    dbSupplierWisePurchaseOptions.Where(x => dbSupplierWisePurchaseOptionModifieds.All(y => y.Id != x.Id));
            }

            #endregion SupplierWisePurchaseOption

            #region MoqmsqRoudingOptionItem
            IEnumerable<MOQMSQRoudingOptionItem> dbMoqmsqRoudingOptionItemModifieds = new List<MOQMSQRoudingOptionItem>();
            IEnumerable<MOQMSQRoudingOptionItem> newMoqmsqRoudingOptionItemAddeds = new List<MOQMSQRoudingOptionItem>();
            IEnumerable<MOQMSQRoudingOptionItem> dbMoqmsqRoudingOptionItemDeletes = new List<MOQMSQRoudingOptionItem>();
            if (command.MoqmsqRoudingOptionItems != null)
            {
                dbMoqmsqRoudingOptionItemModifieds = dbMoqmsqRoudingOptionItems.Where(x => command.MoqmsqRoudingOptionItems.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.MoqmsqRoudingOptionItems.First(c => c.Id == x.Id), x));

                newMoqmsqRoudingOptionItemAddeds = command.MoqmsqRoudingOptionItems.Where(x => x.Id == 0)
                    .Select(x => _mapper.Map<MOQMSQRoudingOptionItem>(x));

                dbMoqmsqRoudingOptionItemDeletes =
                    dbMoqmsqRoudingOptionItems.Where(x => dbMoqmsqRoudingOptionItemModifieds.All(y => y.Id != x.Id));
            }
          

            #endregion MoqmsqRoudingOptionItem

            #region FabricComposition

            var dbFabricCompositionModifieds = dbFabricCompositions.Where(x => command.FabricCompositions.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.FabricCompositions.First(c => c.Id == x.Id), x));

            var newFabricCompositionAddeds = command.FabricCompositions.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<FabricComposition>(x));

            var dbFabricCompositionDeletes =
                dbFabricCompositions.Where(x => dbFabricCompositionModifieds.All(y => y.Id != x.Id));

            #endregion FabricComposition

            #region DynamicColumn

            var dbMaterialRequestDynamicColumnModifieds = dbMaterialRequestDynamicColumns.Where(x => command.DynamicColumns.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(command.DynamicColumns.First(c => c.Id == x.Id), x));

            var newMaterialRequestDynamicColumnAddeds = command.DynamicColumns.Where(x => x.Id == 0)
                .Select(x => _mapper.Map<MaterialRequestDynamicColumn>(x));

            var dbMaterialRequestDynamicColumnDeletes =
                dbMaterialRequestDynamicColumns.Where(x => dbMaterialRequestDynamicColumnModifieds.All(y => y.Id != x.Id));

            #endregion DynamicColumn

            bool result = await _repositoryMaterial.UpdateMaterialRequestAsync(entity, new BaseUpdateEntity<MOQMSQRoudingOptionItem>
            {
                LstDataUpdate = dbMoqmsqRoudingOptionItemModifieds,
                LstDataAdd = newMoqmsqRoudingOptionItemAddeds,
                LstDataDelete = dbMoqmsqRoudingOptionItemDeletes
            }, new BaseUpdateEntity<SupplierWisePurchaseOption>
            {
                LstDataUpdate = dbSupplierWisePurchaseOptionModifieds,
                LstDataAdd = newSupplierWisePurchaseOptionAddeds,
                LstDataDelete = dbSupplierWisePurchaseOptionDeletes
            },
            new BaseUpdateEntity<FabricComposition>
            {
                LstDataUpdate = dbFabricCompositionModifieds,
                LstDataAdd = newFabricCompositionAddeds,
                LstDataDelete = dbFabricCompositionDeletes
            },
            new BaseUpdateEntity<MaterialRequestDynamicColumn>
            {
                LstDataUpdate = dbMaterialRequestDynamicColumnModifieds,
                LstDataAdd = newMaterialRequestDynamicColumnAddeds,
                LstDataDelete = dbMaterialRequestDynamicColumnDeletes
            });

            return new Response<bool>(result);
        }
    }
}