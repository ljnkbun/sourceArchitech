using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.TestGroups
{
    public class GetTestGroupQuery : IRequest<Response<TestGroup>>
    {
        public int Id { get; set; }
    }
    public class GetTestGroupQueryHandler : IRequestHandler<GetTestGroupQuery, Response<TestGroup>>
    {
        private readonly ITestGroupRepository _repository;
        public GetTestGroupQueryHandler(ITestGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<TestGroup>> Handle(GetTestGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"TestGroups Not Found (Id:{query.Id}).");
            return new Response<TestGroup>(entity);
        }
    }
}
