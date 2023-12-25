using AutoMapper;
using Shopfloor.Master.Application.Command.DeliveryTerms;
using Shopfloor.Master.Application.Models.DeliveryTerms;
using Shopfloor.Master.Application.Parameters.DeliveryTerms;
using Shopfloor.Master.Application.Query.DeliveryTerms;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.DeliveryTerms
{
    public class DeliveryTermProfile : Profile
    {
        public DeliveryTermProfile()
        {
            CreateMap<DeliveryTerm, DeliveryTermModel>().ReverseMap();
            CreateMap<CreateDeliveryTermCommand, DeliveryTerm>();
            CreateMap<GetDeliveryTermsQuery, DeliveryTermParameter>();
        }
    }
}
