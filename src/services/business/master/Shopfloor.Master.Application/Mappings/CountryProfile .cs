using AutoMapper;
using Shopfloor.Master.Application.Command.Countries;
using Shopfloor.Master.Application.Models.Countries;
using Shopfloor.Master.Application.Parameters.Countries;
using Shopfloor.Master.Application.Query.Countries;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Countries
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<GetCountriesQuery, CountryParameter>();
        }
    }
}
