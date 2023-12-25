using AutoMapper;
using Shopfloor.IED.Application.Command.Concentrates;
using Shopfloor.IED.Application.Models.Concentrates;
using Shopfloor.IED.Application.Parameters.Concentrates;
using Shopfloor.IED.Application.Query.Concentrates;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Concentrates
{
    public class ConcentrateProfile : Profile
    {
        public ConcentrateProfile()
        {
            CreateMap<Concentrate, ConcentrateModel>().ReverseMap();
            CreateMap<CreateConcentrateCommand, Concentrate>();
            CreateMap<GetConcentratesQuery, ConcentrateParameter>();
        }
    }
}
