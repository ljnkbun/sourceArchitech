using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.Attachments
{
    public class UpdateAttachmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
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

            entity.ProductionOutputId = command.ProductionOutputId;
            entity.DefectCapturing100PointsId = command.DefectCapturing100PointsId;
            entity.DefectCapturing4PointsId = command.DefectCapturing4PointsId;
            entity.DefectCapturingStandardId = command.DefectCapturingStandardId;
            entity.FileName = command.FileName;
            entity.Description = command.Description;
            entity.FileId = command.FileId;
            entity.FileType = command.FileType;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
