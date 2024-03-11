using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.Attachments
{
    public class UpdateAttachmentCommand : IRequest<Response<int>>
    {
        public int? InspectionId { get; set; }
        public int? Inpection4PointSysId { get; set; }
        public int? Inpection100PointSysId { get; set; }
        public int? InpectionTCStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
        public int Id { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateAttachmentCommandHandler : IRequestHandler<UpdateAttachmentCommand, Response<int>>
    {
        private readonly IAttachmentRepository _repository;
        public UpdateAttachmentCommandHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateAttachmentCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Attachment Not Found.");
            entity.IsActive = command.IsActive;
            entity.InspectionId = command.InspectionId;
            entity.Inpection4PointSysId = command.Inpection4PointSysId;
            entity.Inpection100PointSysId = command.Inpection100PointSysId;
            entity.InpectionTCStandardId = command.InpectionTCStandardId;
            entity.FileName = command.FileName;
            entity.Description = command.Description;
            entity.FileId = command.FileId;
            entity.FileType = command.FileType;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
