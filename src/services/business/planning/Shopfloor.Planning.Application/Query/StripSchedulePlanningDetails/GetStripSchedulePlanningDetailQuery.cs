using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripSchedulePlanningDetails
{
    public class GetStripSchedulePlanningDetailQuery : IRequest<Response<StripSchedulePlanningDetail>>
    {
        public int Id { get; set; }
    }
    public class GetStripSchedulePlanningDetailQueryHandler : IRequestHandler<GetStripSchedulePlanningDetailQuery, Response<StripSchedulePlanningDetail>>
    {
        private readonly IStripSchedulePlanningDetailRepository _repository;
        public GetStripSchedulePlanningDetailQueryHandler(IStripSchedulePlanningDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripSchedulePlanningDetail>> Handle(GetStripSchedulePlanningDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripSchedulePlanningDetail Not Found (Id:{query.Id}).");
            return new Response<StripSchedulePlanningDetail>(entity);
        }
    }
}
