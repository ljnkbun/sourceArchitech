using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Attachments
{
    public class DeleteAttachmentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand, Response<int>>
    {
        private readonly IAttachmentRepository _repository;
        public DeleteAttachmentCommandHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteAttachmentCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Attachment Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
