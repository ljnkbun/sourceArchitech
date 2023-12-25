using AutoMapper;
using Shopfloor.IED.Application.Command.DCTemplates;
using Shopfloor.IED.Application.Models.DCTemplates;
using Shopfloor.IED.Application.Parameters.DCTemplates;
using Shopfloor.IED.Application.Query.DCTemplates;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DCTemplateProfile : Profile
    {
        public DCTemplateProfile()
        {
            CreateMap<DCTemplate, DCTemplateModel>().ReverseMap();
            CreateMap<CreateDCTemplateCommand, DCTemplate>();
            CreateMap<GetDCTemplatesQuery, DCTemplateParameter>();
        }
    }
}