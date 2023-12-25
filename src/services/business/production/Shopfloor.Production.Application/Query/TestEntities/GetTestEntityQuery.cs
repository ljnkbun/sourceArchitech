using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.TestEntities
{
    public class GetTestEntityQuery : IRequest<Response<TestEntity>>
    {
        public int Id { get; set; }
    }
    public class GetTestEntityQueryHandler : IRequestHandler<GetTestEntityQuery, Response<TestEntity>>
    {
        private readonly ITestEntityRepository _repository;
        public GetTestEntityQueryHandler(ITestEntityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<TestEntity>> Handle(GetTestEntityQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"TestEntity Not Found (Id:{query.Id}).");
            return new Response<TestEntity>(entity);
        }
    }
}
