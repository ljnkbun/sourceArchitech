using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingFiles
{
    public class GetKnittingFileQuery : IRequest<Response<KnittingFile>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingFileQueryHandler : IRequestHandler<GetKnittingFileQuery, Response<KnittingFile>>
    {
        private readonly IKnittingFileRepository _repository;
        public GetKnittingFileQueryHandler(IKnittingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingFile>> Handle(GetKnittingFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingFile Not Found (Id:{query.Id}).");
            return new Response<KnittingFile>(entity);
        }
    }
}
