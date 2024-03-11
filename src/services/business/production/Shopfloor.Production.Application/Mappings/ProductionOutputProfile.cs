using AutoMapper;
using Shopfloor.Production.Application.Command.ProductionOutputs;
using Shopfloor.Production.Application.Models.ProductionOutputs;
using Shopfloor.Production.Application.Parameters.ProductionOutputs;
using Shopfloor.Production.Application.Query.ProductionOutputs;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class ProductionOutputProfile : Profile
    {
        public ProductionOutputProfile()
        {
            CreateMap<ProductionOutput, ProductionOutputModel>().ReverseMap();
            CreateMap<CreateProductionOutputCommand, ProductionOutput>();
            CreateMap<GetProductionOutputsQuery, ProductionOutputParameter>();
        }
    }
}
