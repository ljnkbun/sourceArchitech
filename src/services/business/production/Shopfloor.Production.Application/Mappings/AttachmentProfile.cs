using AutoMapper;
using Shopfloor.EventBus.Models.Responses.ProductionOutputs;
using Shopfloor.Production.Application.Command.Attachments;
using Shopfloor.Production.Application.Models.Attachments;
using Shopfloor.Production.Application.Parameters.Attachments;
using Shopfloor.Production.Application.Query.Attachments;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Application.Mappings
{
    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentModel>().ReverseMap();
            CreateMap<Attachment, AttachmentDto>().ReverseMap();
            CreateMap<CreateAttachmentCommand, Attachment>();
            CreateMap<GetAttachmentsQuery, AttachmentParameter>();
        }
    }
}
