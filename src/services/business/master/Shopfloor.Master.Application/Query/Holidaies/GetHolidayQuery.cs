using MediatR;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Application.Query.Holidays
{
    public class GetHolidayQuery : IRequest<Response<Holiday>>
    {
        public int Id { get; set; }
    }
    public class GetHolidayQueryHandler : IRequestHandler<GetHolidayQuery, Response<Holiday>>
    {
        private readonly IHolidayRepository _repository;
        public GetHolidayQueryHandler(IHolidayRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Holiday>> Handle(GetHolidayQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Holidays Not Found (Id:{query.Id}).");
            return new Response<Holiday>(entity);
        }
    }
}
