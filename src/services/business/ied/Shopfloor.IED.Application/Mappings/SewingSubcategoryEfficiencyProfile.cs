using AutoMapper;
using Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Application.Models.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class SewingSubcategoryEfficiencyProfile : Profile
    {
        public SewingSubcategoryEfficiencyProfile()
        {
            CreateMap<SewingSubcategoryEfficiency, SewingSubcategoryEfficiencyModel>().ReverseMap();
            CreateMap<CreateSewingSubcategoryEfficiencyCommand, SewingSubcategoryEfficiency>();
            CreateMap<GetSewingSubcategoryEfficienciesQuery, SewingSubcategoryEfficiencyParameter>();
        }
    }
}