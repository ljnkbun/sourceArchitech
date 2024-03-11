using AutoMapper;
using Shopfloor.IED.Application.Models.SewingRoutingBOLs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingRoutingBOLs
{
    public class SewingRoutingBOLProfile : Profile
    {
        public SewingRoutingBOLProfile()
        {
            CreateMap<SewingRoutingBOL, SewingRoutingBOLModel>().ReverseMap();
        }
    }
}
