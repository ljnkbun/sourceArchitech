using AutoMapper;
using Shopfloor.EventBus.Models.Requests.Barcodes;
using Shopfloor.EventBus.Models.Responses.Barcodes;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Command.InspectionBySizes;
using Shopfloor.Production.Application.Models.InspectionBySizes;
using Shopfloor.Production.Application.Parameters.InspectionBySizes;
using Shopfloor.Production.Application.Query.InspectionBySizes;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class InspectionBySizeProfile : Profile
    {
        public InspectionBySizeProfile()
        {
            CreateMap<InspectionBySize, InspectionBySizeModel>().ReverseMap();
            CreateMap<InspectionBySize, InspectionBySizeDto>().ReverseMap();
            CreateMap<CreateInspectionBySizeCommand, InspectionBySize>();
            CreateMap<GetInspectionBySizesQuery, InspectionBySizeParameter>();
            CreateMap<CreateBarcodeCommand, CreateArticleBarcodeRequest>();
            CreateMap<PrintBarcodeModel, ArticleBarcodeModel>().ReverseMap();
        }
    }
}
