using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Counts
{
    public class GetCountQuery : IRequest<Response<Count>>
    {
        public int Id { get; set; }
    }
    public class GetCountQueryHandler : IRequestHandler<GetCountQuery, Response<Count>>
    {
        private readonly ICountRepository _repository;
        public GetCountQueryHandler(ICountRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Count>> Handle(GetCountQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Count Not Found (Id:{query.Id}).");
            return new Response<Count>(entity);
        }
    }
}
