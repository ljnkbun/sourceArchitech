using AutoMapper;
using Shopfloor.IED.Application.Command.ProcessTemplateItems;
using Shopfloor.IED.Application.Models.ProcessTemplateItems;
using Shopfloor.IED.Application.Parameters.ProcessTemplateItems;
using Shopfloor.IED.Application.Query.ProcessTemplateItems;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.ProcessTemplateItems
{
    public class ProcessTemplateItemProfile : Profile
    {
        public ProcessTemplateItemProfile()
        {
            CreateMap<ProcessTemplateItem, ProcessTemplateItemModel>().ReverseMap();
            CreateMap<CreateProcessTemplateItemCommand, ProcessTemplateItem>();
            CreateMap<GetProcessTemplateItemsQuery, ProcessTemplateItemParameter>();
        }
    }
}
