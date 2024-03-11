using AutoMapper;
using MediatR;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class CreateStripFactoryCommand : IRequest<Core.Models.Responses.Response<int>>
    {
        public int PlanningGroupFactoryId { get; set; }
        public int PORId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainningQuantity { get; set; }
        public bool IsAllocated { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsSplitBatch { get; set; }
    }
    public class CreateStripFactoryCommandHandler : IRequestHandler<CreateStripFactoryCommand, Core.Models.Responses.Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStripFactoryRepository _repository;
        private readonly IPORRepository _wfxPORRepository;

        public CreateStripFactoryCommandHandler(IMapper mapper,
            IStripFactoryRepository repository,
            IPORRepository wfxPORRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _wfxPORRepository = wfxPORRepository;
        }

        public async Task<Core.Models.Responses.Response<int>> Handle(CreateStripFactoryCommand request, CancellationToken cancellationToken)
        {
            // Validate WfxPOR
            if (await _wfxPORRepository.GetByIdAsync(request.PORId) == null) return new("WfxPOR Not Found.");

            request.PlanningGroupFactoryId = default(int); //FactoryProcessRes.Message.Id;
            var entity = _mapper.Map<StripFactory>(request);
            var result = await _repository.InsertStripFactory(entity);
            if (result == null)
                return new("Cannot Insert StripFactory.");
            return new Core.Models.Responses.Response<int>(result.Value);
        }
    }
}
