using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Query.StripFactoryScheduleDetails
{
    public class GetStripFactoryScheduleDetailQuery : IRequest<Response<StripFactoryScheduleDetail>>
    {
        public int Id { get; set; }
    }
    public class GetStripFactoryScheduleDetailQueryHandler : IRequestHandler<GetStripFactoryScheduleDetailQuery, Response<StripFactoryScheduleDetail>>
    {
        private readonly IStripFactoryScheduleDetailRepository _repository;
        public GetStripFactoryScheduleDetailQueryHandler(IStripFactoryScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<StripFactoryScheduleDetail>> Handle(GetStripFactoryScheduleDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"StripFactoryScheduleDetails Not Found (Id:{query.Id}).");
            return new Response<StripFactoryScheduleDetail>(entity);
        }
    }
}
