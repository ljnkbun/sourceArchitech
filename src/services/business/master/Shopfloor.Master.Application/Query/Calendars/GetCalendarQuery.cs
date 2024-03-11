using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Calendars
{
    public class GetCalendarQuery : IRequest<Response<Calendar>>
    {
        public int Id { get; set; }
    }
    public class GetCalendarQueryHandler : IRequestHandler<GetCalendarQuery, Response<Calendar>>
    {
        private readonly ICalendarRepository _repository;
        public GetCalendarQueryHandler(ICalendarRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Calendar>> Handle(GetCalendarQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Calendar Not Found (Id:{query.Id}).");
            return new Response<Calendar>(entity);
        }
    }
}
