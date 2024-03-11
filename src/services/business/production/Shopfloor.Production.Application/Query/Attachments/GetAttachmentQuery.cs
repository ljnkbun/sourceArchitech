using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.Attachments
{
    public class GetAttachmentQuery : IRequest<Response<Attachment>>
    {
        public int Id { get; set; }
    }
    public class GetAttachmentQueryHandler : IRequestHandler<GetAttachmentQuery, Response<Attachment>>
    {
        private readonly IAttachmentRepository _repository;
        public GetAttachmentQueryHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Attachment>> Handle(GetAttachmentQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Attachment Not Found (Id:{query.Id}).");
            return new Response<Attachment>(entity);
        }
    }
}
