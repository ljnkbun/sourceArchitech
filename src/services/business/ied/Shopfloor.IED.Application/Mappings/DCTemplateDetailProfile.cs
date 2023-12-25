using AutoMapper;
using Shopfloor.IED.Application.Command.DCTemplateDetails;
using Shopfloor.IED.Application.Models.DCTemplateDetails;
using Shopfloor.IED.Application.Parameters.DCTemplateDetails;
using Shopfloor.IED.Application.Query.DCTemplateDetails;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DCTemplateDetailProfile : Profile
    {
        public DCTemplateDetailProfile()
        {
            CreateMap<DCTemplateDetail, DCTemplateDetailModel>().ReverseMap();
            CreateMap<CreateDCTemplateDetailCommand, DCTemplateDetail>();
            CreateMap<GetDCTemplateDetailsQuery, DCTemplateDetailParameter>();
        }
    }
}