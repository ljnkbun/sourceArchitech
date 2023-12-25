using AutoMapper;
using Shopfloor.Master.Application.Command.Currencies;
using Shopfloor.Master.Application.Models.Currencies;
using Shopfloor.Master.Application.Parameters.Currencies;
using Shopfloor.Master.Application.Query.Currencies;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Currencies
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyModel>().ReverseMap();
            CreateMap<CreateCurrencyCommand, Currency>();
            CreateMap<GetCurrenciesQuery, CurrencyParameter>();
        }
    }
}
