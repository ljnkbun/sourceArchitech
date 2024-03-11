using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.StripFactorySchedules
{
    public class GetStripFactoryScheduleQuery : IRequest<Response<StripFactorySchedule>>
    {
        public int Id { get; set; }
    }
    public class GetStripFactoryScheduleQueryHandler : IRequestHandler<GetStripFactoryScheduleQuery, Response<StripFactorySchedule>>
    {
        private readonly IStripFactoryScheduleRepository _repository;
        public GetStripFactoryScheduleQueryHandler(IStripFactoryScheduleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripFactorySchedule>> Handle(GetStripFactoryScheduleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripFactorySchedules Not Found (Id:{query.Id}).");
            return new Response<StripFactorySchedule>(entity);
        }
    }
}
