using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripScheduleDetails
{
    public class GetStripScheduleDetailQuery : IRequest<Response<StripScheduleDetail>>
    {
        public int Id { get; set; }
    }
    public class GetStripScheduleDetailQueryHandler : IRequestHandler<GetStripScheduleDetailQuery, Response<StripScheduleDetail>>
    {
        private readonly IStripScheduleDetailRepository _repository;
        public GetStripScheduleDetailQueryHandler(IStripScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripScheduleDetail>> Handle(GetStripScheduleDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripScheduleDetail Not Found (Id:{query.Id}).");
            return new Response<StripScheduleDetail>(entity);
        }
    }
}
