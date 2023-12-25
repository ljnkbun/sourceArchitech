using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.FiberTypes
{
    public class GetFiberTypeQuery : IRequest<Response<FiberType>>
    {
        public int Id { get; set; }
    }
    public class GetFiberTypeQueryHandler : IRequestHandler<GetFiberTypeQuery, Response<FiberType>>
    {
        private readonly IFiberTypeRepository _repository;
        public GetFiberTypeQueryHandler(IFiberTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FiberType>> Handle(GetFiberTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"FiberType Not Found (Id:{query.Id}).");
            return new Response<FiberType>(entity);
        }
    }
}
