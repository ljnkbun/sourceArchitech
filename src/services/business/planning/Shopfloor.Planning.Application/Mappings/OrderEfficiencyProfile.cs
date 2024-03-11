using AutoMapper;
using Shopfloor.Planning.Application.Command.OrderEfficiencies;
using Shopfloor.Planning.Application.Models.OrderEfficiencies;
using Shopfloor.Planning.Application.Parameters.OrderEfficiencies;
using Shopfloor.Planning.Application.Query.OrderEfficiencies;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class OrderEfficiencyProfile : Profile
    {
        public OrderEfficiencyProfile()
        {
            CreateMap<OrderEfficiency, OrderEfficiencyModel>();
            CreateMap<CreateOrderEfficiencyCommand, OrderEfficiency>();
            CreateMap<GetOrderEfficienciesQuery, OrderEfficiencyParameter>();
        }
    }
}
