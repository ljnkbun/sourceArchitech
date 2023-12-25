using AutoMapper;
using Shopfloor.Master.Application.Command.FiberTypes;
using Shopfloor.Master.Application.Models.FiberTypes;
using Shopfloor.Master.Application.Parameters.FiberTypes;
using Shopfloor.Master.Application.Query.FiberTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.FiberTypes
{
    public class FiberTypeProfile : Profile
    {
        public FiberTypeProfile()
        {
            CreateMap<FiberType, FiberTypeModel>().ReverseMap();
            CreateMap<CreateFiberTypeCommand, FiberType>();
            CreateMap<GetFiberTypesQuery, FiberTypeParameter>();
        }
    }
}
