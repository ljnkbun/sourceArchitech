using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CalendarDetails
{
    public class GetCalendarDetailQuery : IRequest<Response<CalendarDetail>>
    {
        public int Id { get; set; }
    }
    public class GetCalendarDetailQueryHandler : IRequestHandler<GetCalendarDetailQuery, Response<CalendarDetail>>
    {
        private readonly ICalendarDetailRepository _repository;
        public GetCalendarDetailQueryHandler(ICalendarDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CalendarDetail>> Handle(GetCalendarDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"CalendarDetail Not Found (Id:{query.Id}).");
            return new Response<CalendarDetail>(entity);
        }
    }
}
