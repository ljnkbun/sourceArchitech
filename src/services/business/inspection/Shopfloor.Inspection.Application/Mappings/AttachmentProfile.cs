using AutoMapper;
using Shopfloor.Inspection.Application.Command.Attachments;
using Shopfloor.Inspection.Application.Models.Attachments;
using Shopfloor.Inspection.Application.Parameters.Attachments;
using Shopfloor.Inspection.Application.Query.Attachments;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Attachments
{
    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentModel>().ReverseMap();
            CreateMap<CreateAttachmentCommand, Attachment>();
            CreateMap<GetAttachmentsQuery, AttachmentParameter>();
        }
    }
}
