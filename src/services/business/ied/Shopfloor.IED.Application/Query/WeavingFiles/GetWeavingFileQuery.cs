using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingFiles
{
    public class GetWeavingFileQuery : IRequest<Response<WeavingFile>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingFileQueryHandler : IRequestHandler<GetWeavingFileQuery, Response<WeavingFile>>
    {
        private readonly IWeavingFileRepository _repository;
        public GetWeavingFileQueryHandler(IWeavingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingFile>> Handle(GetWeavingFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingFile Not Found (Id:{query.Id}).");
            return new Response<WeavingFile>(entity);
        }
    }
}
