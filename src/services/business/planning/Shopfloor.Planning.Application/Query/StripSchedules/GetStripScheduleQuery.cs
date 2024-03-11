using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripSchedules
{
    public class GetStripScheduleQuery : IRequest<Response<StripSchedule>>
    {
        public int Id { get; set; }
    }
    public class GetStripScheduleQueryHandler : IRequestHandler<GetStripScheduleQuery, Response<StripSchedule>>
    {
        private readonly IStripScheduleRepository _repository;
        public GetStripScheduleQueryHandler(IStripScheduleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripSchedule>> Handle(GetStripScheduleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripSchedule Not Found (Id:{query.Id}).");
            return new Response<StripSchedule>(entity);
        }
    }
}
