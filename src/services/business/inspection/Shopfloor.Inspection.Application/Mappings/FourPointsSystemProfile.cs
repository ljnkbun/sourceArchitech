using AutoMapper;
using Shopfloor.Inspection.Application.Command.FourPointsSystems;
using Shopfloor.Inspection.Application.Models.FourPointsSystems;
using Shopfloor.Inspection.Application.Parameters.FourPointsSystems;
using Shopfloor.Inspection.Application.Query.FourPointsSystems;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.FourPointsSystems
{
    public class FourPointsSystemProfile : Profile
    {
        public FourPointsSystemProfile()
        {
            CreateMap<FourPointsSystem, FourPointsSystemModel>().ReverseMap();
            CreateMap<CreateFourPointsSystemCommand, FourPointsSystem>();
            CreateMap<GetFourPointsSystemsQuery, FourPointsSystemParameter>();
        }
    }
}
