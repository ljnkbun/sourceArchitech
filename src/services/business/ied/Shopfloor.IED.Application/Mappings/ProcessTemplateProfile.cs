using AutoMapper;
using Shopfloor.IED.Application.Command.ProcessTemplates;
using Shopfloor.IED.Application.Models.ProcessTemplates;
using Shopfloor.IED.Application.Parameters.ProcessTemplates;
using Shopfloor.IED.Application.Query.ProcessTemplates;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.ProcessTemplates
{
    public class ProcessTemplateProfile : Profile
    {
        public ProcessTemplateProfile()
        {
            CreateMap<ProcessTemplate, ProcessTemplateModel>().ReverseMap();
            CreateMap<CreateProcessTemplateCommand, ProcessTemplate>();
            CreateMap<GetProcessTemplatesQuery, ProcessTemplateParameter>();
        }
    }
}
