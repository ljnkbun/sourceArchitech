using AutoMapper;
using Shopfloor.IED.Application.Command.DCTemplateTasks;
using Shopfloor.IED.Application.Models.DCTemplateTasks;
using Shopfloor.IED.Application.Parameters.DCTemplateTasks;
using Shopfloor.IED.Application.Query.DCTemplateTasks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DCTemplateTaskProfile : Profile
    {
        public DCTemplateTaskProfile()
        {
            CreateMap<DCTemplateTask, DCTemplateTaskModel>().ReverseMap();
            CreateMap<CreateDCTemplateTaskCommand, DCTemplateTask>();
            CreateMap<GetDCTemplateTasksQuery, DCTemplateTaskParameter>();
        }
    }
}