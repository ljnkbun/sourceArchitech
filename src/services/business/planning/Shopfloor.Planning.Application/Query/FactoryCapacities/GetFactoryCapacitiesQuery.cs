using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.FactoryCapacities;
using Shopfloor.Planning.Application.Models.FactoryCapacitys;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.FactoryCapacitys
{
    public class GetFactoryCapacitiesQuery : IRequest<PagedResponse<IReadOnlyList<FactoryCapcityCustomModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PorNo { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetFactoryCapacitysQueryHandler : IRequestHandler<GetFactoryCapacitiesQuery, PagedResponse<IReadOnlyList<FactoryCapcityCustomModel>>>
    {
        private readonly IFactoryCapacityRepository _repository;
        private readonly IStripFactoryRepository _stripFactoryRepository;
        public GetFactoryCapacitysQueryHandler(
            IFactoryCapacityRepository repository,
            IStripFactoryRepository stripFactoryRepository)
        {
            _repository = repository;
            _stripFactoryRepository = stripFactoryRepository;
        }

        public async Task<PagedResponse<IReadOnlyList<FactoryCapcityCustomModel>>> Handle(GetFactoryCapacitiesQuery request, CancellationToken cancellationToken)
        {
            var factoryCapacityModels = await _repository.GetFactoryCapacityModelByDate<FactoryCapacityModel>(request.FromDate, request.ToDate, request.ProcessId, request.FactoryId);
            var stripFactoryModels = await _stripFactoryRepository.GetDataForFactoryCapacities<StripFactoryForFactoryCapacity>(request.PorNo, request.FromDate, request.ToDate);

            //Map isHighLight
            factoryCapacityModels.ForEach(item =>
            {
                var isStrip = stripFactoryModels.Any(x => x.PlanningGroupFactoryId == item.PlanningGroupFactoryId 
                    && x.StartDate <= item.Date && x.EndDate >= item.Date);
                if (isStrip) item.IsHighLight = true;
            });

            var groupCustomModels = factoryCapacityModels?
                .GroupBy(fcModel => new { fcModel.ProcessId, fcModel.ProcessName, fcModel.FactoryName, fcModel.FactoryId })
                .Select(group => new FactoryCapcityCustomModel
                {
                    FactoryId = group.Key.FactoryId ?? 0,
                    FactoryName = group.Key.FactoryName,
                    PlanningGroupFactoryId = group.First().PlanningGroupFactoryId,
                    ProcessId = group.Key.ProcessId ?? 0,
                    ProcessName = group.Key.ProcessName,
                    FactoryCapacities = group.Select(fcModel => new FactoryCapacityDetail
                    {
                        Date = fcModel.Date,
                        Standingcapacity = fcModel.Standingcapacity,
                        ActualCapacity = fcModel.ActualCapacity,
                        Percent = fcModel.Percent,
                        ColorCode = fcModel.ColorCode,
                        Week = fcModel.Week,
                        Month = fcModel.Month,
                        IsHighLight = fcModel.IsHighLight,
                    }).ToList()
                }).ToList();

            return new PagedResponse<IReadOnlyList<FactoryCapcityCustomModel>>(groupCustomModels, request.PageNumber, request.PageSize);
        }
    }
}
