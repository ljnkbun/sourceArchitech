using AutoMapper;
using Shopfloor.IED.Application.Command.SewingRates;
using Shopfloor.IED.Application.Models.SewingRates;
using Shopfloor.IED.Application.Parameters.SewingRates;
using Shopfloor.IED.Application.Query.SewingRates;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingRates
{
    public class SewingRateProRate : Profile
    {
        public SewingRateProRate()
        {
            CreateMap<SewingRate, SewingRateModel>().ReverseMap();
            CreateMap<CreateSewingRateCommand, SewingRate>();
            CreateMap<GetSewingRatesQuery, SewingRateParameter>();
        }
    }
}
