using AutoMapper;
using Shopfloor.Master.Application.Command.CompanyCurrencies;
using Shopfloor.Master.Application.Models.CompanyCurrencies;
using Shopfloor.Master.Application.Parameters.CompanyCurrencies;
using Shopfloor.Master.Application.Query.CompanyCurrencies;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.CompanyCurrencies
{
    public class CompanyCurrencyProfile : Profile
    {
        public CompanyCurrencyProfile()
        {
            CreateMap<CompanyCurrency, CompanyCurrencyModel>().ReverseMap();
            CreateMap<CreateCompanyCurrencyCommand, CompanyCurrency>();
            CreateMap<GetCompanyCurrenciesQuery, CompanyCurrencyParameter>();
        }
    }
}
