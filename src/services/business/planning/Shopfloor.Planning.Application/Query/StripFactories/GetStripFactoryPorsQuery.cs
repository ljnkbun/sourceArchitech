using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripFactoryPors
{
    public class GetStripFactoryPorsQuery : IRequest<Response<IReadOnlyList<StripFactoryPorModel>>>
    {
        public int PlanningGroupFactoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class GetStripFactoryPorsQueryHandler : IRequestHandler<GetStripFactoryPorsQuery, Response<IReadOnlyList<StripFactoryPorModel>>>
    {
        private readonly IStripFactoryRepository _repository;
        public GetStripFactoryPorsQueryHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<IReadOnlyList<StripFactoryPorModel>>> Handle(GetStripFactoryPorsQuery request, CancellationToken cancellationToken)
        {
            return new(await _repository.GetStripFactoryPorsAsync<StripFactoryPorModel>(request.PlanningGroupFactoryId, request.StartDate, request.EndDate));
        }
    }
}
