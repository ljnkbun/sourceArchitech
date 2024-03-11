using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFiles
{
    public class GetSewingFileQuery : IRequest<Response<SewingFile>>
    {
        public int Id { get; set; }
    }
    public class GetSewingFileQueryHandler : IRequestHandler<GetSewingFileQuery, Response<SewingFile>>
    {
        private readonly ISewingFileRepository _repository;
        public GetSewingFileQueryHandler(ISewingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingFile>> Handle(GetSewingFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingFile Not Found (Id:{query.Id}).");
            return new Response<SewingFile>(entity);
        }
    }
}
