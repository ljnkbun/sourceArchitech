using AutoMapper;
using Shopfloor.Master.Application.Command.FabricWidths;
using Shopfloor.Master.Application.Models.FabricWidths;
using Shopfloor.Master.Application.Parameters.FabricWidths;
using Shopfloor.Master.Application.Query.FabricWidths;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class FabricWidthProfile : Profile
    {
        public FabricWidthProfile()
        {
            CreateMap<FabricWidth, FabricWidthModel>().ReverseMap();
            CreateMap<CreateFabricWidthCommand, FabricWidth>();
            CreateMap<GetFabricWidthsQuery, FabricWidthParameter>();
        }
    }
}
