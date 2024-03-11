using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Domain.Interfaces;

namespace Shopfloor.FileStorage.Application.Query.Files
{
    public class GetFileQuery : IRequest<Response<Domain.Entities.File>>
    {
        public int Id { get; set; }
    }
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, Response<Domain.Entities.File>>
    {
        private readonly IFileRepository _repository;
        public GetFileQueryHandler(IFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Domain.Entities.File>> Handle(GetFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id)
                ?? throw new ApiException($"File Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.File>(entity);
        }
    }
}
