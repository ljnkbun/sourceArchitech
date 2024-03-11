using AutoMapper;
using Shopfloor.IED.Application.Command.LiquorRatios;
using Shopfloor.IED.Application.Models.LiquorRatios;
using Shopfloor.IED.Application.Parameters.LiquorRatios;
using Shopfloor.IED.Application.Query.LiquorRatios;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.LiquorRatios
{
    public class LiquorRatioProfile : Profile
    {
        public LiquorRatioProfile()
        {
            CreateMap<LiquorRatio, LiquorRatioModel>().ReverseMap();
            CreateMap<CreateLiquorRatioCommand, LiquorRatio>();
            CreateMap<GetLiquorRatiosQuery, LiquorRatioParameter>();
        }
    }
}
