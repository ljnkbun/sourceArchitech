using AutoMapper;
using Shopfloor.Inspection.Application.Command.FabricWeights;
using Shopfloor.Inspection.Application.Models.FabricWeights;
using Shopfloor.Inspection.Application.Parameters.FabricWeights;
using Shopfloor.Inspection.Application.Query.FabricWeights;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.FabricWeights
{
    public class FabricWeightProfile : Profile
    {
        public FabricWeightProfile()
        {
            CreateMap<FabricWeight, FabricWeightModel>().ReverseMap();
            CreateMap<CreateFabricWeightCommand, FabricWeight>();
            CreateMap<GetFabricWeightsQuery, FabricWeightParameter>();
        }
    }
}
