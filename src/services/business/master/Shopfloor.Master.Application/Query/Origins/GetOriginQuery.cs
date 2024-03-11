using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Origins
{
    public class GetOriginQuery : IRequest<Response<Origin>>
    {
        public int Id { get; set; }
    }
    public class GetOriginQueryHandler : IRequestHandler<GetOriginQuery, Response<Origin>>
    {
        private readonly IOriginRepository _repository;
        public GetOriginQueryHandler(IOriginRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Origin>> Handle(GetOriginQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Origin Not Found (Id:{query.Id}).");
            return new Response<Origin>(entity);
        }
    }
}
