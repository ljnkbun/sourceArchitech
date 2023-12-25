using AutoMapper;
using Shopfloor.Master.Application.Command.FabricContents;
using Shopfloor.Master.Application.Models.FabricContents;
using Shopfloor.Master.Application.Parameters.FabricContents;
using Shopfloor.Master.Application.Query.FabricContents;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class FabricContentProfile : Profile
    {
        public FabricContentProfile()
        {
            CreateMap<FabricContent, FabricContentModel>().ReverseMap();
            CreateMap<CreateFabricContentCommand, FabricContent>();
            CreateMap<GetFabricContentsQuery, FabricContentParameter>();
        }
    }
}
