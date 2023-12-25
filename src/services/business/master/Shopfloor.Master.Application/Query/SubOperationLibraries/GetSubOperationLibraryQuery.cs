using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SubOperationLibraries
{
    public class GetSubOperationLibraryQuery : IRequest<Response<SubOperationLibrary>>
    {
        public int Id { get; set; }
    }
    public class GetSubOperationLibraryQueryHandler : IRequestHandler<GetSubOperationLibraryQuery, Response<SubOperationLibrary>>
    {
        private readonly ISubOperationLibraryRepository _repository;
        public GetSubOperationLibraryQueryHandler(ISubOperationLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SubOperationLibrary>> Handle(GetSubOperationLibraryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SubOperationLibrary Not Found (Id:{query.Id}).");
            return new Response<SubOperationLibrary>(entity);
        }
    }
}
