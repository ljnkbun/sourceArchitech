using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.ProcessLibraries
{
    public class GetProcessLibraryQuery : IRequest<Response<ProcessLibrary>>
    {
        public int Id { get; set; }
    }
    public class GetProcessLibraryQueryHandler : IRequestHandler<GetProcessLibraryQuery, Response<ProcessLibrary>>
    {
        private readonly IProcessLibraryRepository _repository;
        public GetProcessLibraryQueryHandler(IProcessLibraryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProcessLibrary>> Handle(GetProcessLibraryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"ProcessLibrary Not Found (Id:{query.Id}).");
            return new Response<ProcessLibrary>(entity);
        }
    }
}
