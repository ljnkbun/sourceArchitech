using AutoMapper;
using MediatR;
using Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups;
using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories;
using Shopfloor.EventBus.Services;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class SaveStripFactoriesCommand : IRequest<Core.Models.Responses.Response<bool>>
    {
        public List<UpdateStripFactoryCommand> StripFactories { get; set; }
    }
    public class SaveOrUpdateCommandHandler : IRequestHandler<SaveStripFactoriesCommand, Core.Models.Responses.Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryRepository _repository;
        private readonly IPORRepository _wfxPORRepository;
        private readonly IRequestClientService _requestClientService;

        public SaveOrUpdateCommandHandler(IMapper mapper,
            IStripFactoryRepository repository,
            IPORRepository wfxPORRepository,
            IRequestClientService requestClientService)
        {
            _repository = repository;
            _mapper = mapper;
            _wfxPORRepository = wfxPORRepository;
            _requestClientService = requestClientService;
        }

        public async Task<Core.Models.Responses.Response<bool>> Handle(SaveStripFactoriesCommand request, CancellationToken cancellationToken)
        {
            if (request.StripFactories.Count == 0)
                return new($"Data invalid please check again!.");

            if(request.StripFactories.Any(x => x.IsAllocated))
                return new($"StripFactory already Allocated. Cannot Allocated again!.");

            var pgfIds = request.StripFactories.Select(x => x.PlanningGroupFactoryId).Distinct().ToList();
            var planningGroupFactoryRes =
               await _requestClientService.GetResponseAsync<GetPlanningGroupFactoryByIdsRequest, GetPlanningGroupFactoryByIdsResponse>(new() { Ids = pgfIds }, cancellationToken);

            if (planningGroupFactoryRes?.Message?.PlanningGroupFactrories == null || !planningGroupFactoryRes.Message.PlanningGroupFactrories.Any())
                return new($"Factories invalid please check again!.");

            var dataStripFactories = await _repository.GetAllAsync();
            var wfxPors = await _wfxPORRepository.GetAllAsync();
            var stripFactoies = new List<StripFactory>();

            var porIds = request.StripFactories.Select(x => x.PORId).Distinct().ToList();
            var existsPorIds = wfxPors.Where(por => porIds.Contains(por.Id)).Select(por => por.Id).ToList();
            var matchPorIds = porIds.Except(existsPorIds).ToList();

            if (matchPorIds.Any())
                return new($"PORIds found: {string.Join(", ", matchPorIds)}");

            foreach (var item in request.StripFactories.Where(x => x.Id > 0))
            {
                stripFactoies.Add(UpdateStripFactory(item, dataStripFactories));
            }

            foreach (var item in request.StripFactories.Where(x => x.Id == 0))
            {
                stripFactoies.Add(_mapper.Map<StripFactory>(item));
            }

            var result = await _repository.SaveMultipleStripFactory(stripFactoies);
            return new Core.Models.Responses.Response<bool>(result);
        }
        private StripFactory UpdateStripFactory(UpdateStripFactoryCommand item, IReadOnlyList<StripFactory> stripFactories)
        {
            var entity = stripFactories.FirstOrDefault(x => x.Id == item.Id);
            if (entity != null)
            {
                entity.IsActive = item.IsActive;
                entity.PlanningGroupFactoryId = item.PlanningGroupFactoryId;
                entity.PORId = item.PORId;
                entity.Quantity = item.Quantity;
                entity.StartDate = item.StartDate;
                entity.EndDate = item.EndDate;
                entity.IsPlanning = item.IsPlanning;
                entity.StripFactoryDetails = _mapper.Map<ICollection<StripFactoryDetail>>(item.StripFactoryDetails);
            }
            return entity;
        }
    }
}
