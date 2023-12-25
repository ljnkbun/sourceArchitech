using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.OperationLibraries
{
    public class GetOperationLibraryQuery : IRequest<Response<OperationLibrary>>
    {
        public int Id { get; set; }
    }
    public class GetOperationLibraryQueryHandler : IRequestHandler<GetOperationLibraryQuery, Response<OperationLibrary>>
    {
        private readonly IOperationLibraryRepository _repository;
        public GetOperationLibraryQueryHandler(IOperationLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<OperationLibrary>> Handle(GetOperationLibraryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"OperationLibrary Not Found (Id:{query.Id}).");
            return new Response<OperationLibrary>(entity);
        }
    }
}
