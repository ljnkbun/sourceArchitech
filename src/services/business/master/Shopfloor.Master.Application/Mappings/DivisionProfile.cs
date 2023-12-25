using AutoMapper;
using Shopfloor.Master.Application.Command.Divisions;
using Shopfloor.Master.Application.Models.Divisions;
using Shopfloor.Master.Application.Parameters.Divisions;
using Shopfloor.Master.Application.Query.Divisions;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class DivisionProfile : Profile
    {
        public DivisionProfile()
        {
            CreateMap<Division, DivisionModel>().ReverseMap();
            CreateMap<CreateDivisionCommand, Division>();
            CreateMap<GetDivisionsQuery, DivisionParameter>();
        }
    }
}
