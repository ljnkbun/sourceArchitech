using AutoMapper;

using Shopfloor.Material.Application.Command.MaterialRequests;
using Shopfloor.Material.Application.Models.FabricCompositions;
using Shopfloor.Material.Application.Models.MaterialRequests;
using Shopfloor.Material.Application.Models.MOQMSQRoudingOptionItems;
using Shopfloor.Material.Application.Models.SupplierWisePurchaseOptions;
using Shopfloor.Material.Application.Parameters.MaterialRequests;
using Shopfloor.Material.Application.Query.MaterialRequests;
using Shopfloor.Material.Domain.Entities;
using MaterialRequestDynamicColumn = Shopfloor.Material.Domain.Entities.MaterialRequestDynamicColumn;

namespace Shopfloor.Material.Application.Mappings
{
    public class MaterialRequestProfile : Profile
    {
        public MaterialRequestProfile()
        {
            CreateMap<FabricComposition, FabricCompositionModel>().ReverseMap();
            CreateMap<MOQMSQRoudingOptionItem, MOQMSQRoudingOptionItemModel>().ReverseMap();
            CreateMap<SupplierWisePurchaseOption, SupplierWisePurchaseOptionModel>().ReverseMap();
            CreateMap<GetMaterialRequestsQuery, MaterialRequestParameter>().ReverseMap();
            CreateMap<CreateMaterialRequestCommand, MaterialRequest>().ReverseMap();
            CreateMap<UpdateMaterialRequestCommand, MaterialRequest>().ReverseMap();
            CreateMap<MaterialImportExcelModel, MaterialRequest>().ReverseMap();
            CreateMap<MaterialRequest, MaterialRequestModel>().ReverseMap();
            CreateMap<MaterialRequestDynamicColumn, MaterialRequestDynamicColumnModel>().ReverseMap();
        }
    }
}