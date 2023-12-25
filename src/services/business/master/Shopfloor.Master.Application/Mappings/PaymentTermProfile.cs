using AutoMapper;
using Shopfloor.Master.Application.Command.PaymentTerms;
using Shopfloor.Master.Application.Models.PaymentTerms;
using Shopfloor.Master.Application.Parameters.PaymentTerms;
using Shopfloor.Master.Application.Query.PaymentTerms;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.PaymentTerms
{
    public class PaymentTermProfile : Profile
    {
        public PaymentTermProfile()
        {
            CreateMap<PaymentTerm, PaymentTermModel>().ReverseMap();
            CreateMap<CreatePaymentTermCommand, PaymentTerm>();
            CreateMap<GetPaymentTermsQuery, PaymentTermParameter>();
        }
    }
}
