using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroupFactories
{
    public class CreatePlanningGroupFactoryCommand : IRequest<Response<int>>
    {
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
    }
    public class CreatePlanningGroupFactoryCommandHandler : IRequestHandler<CreatePlanningGroupFactoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanningGroupFactoryRepository _repository;
        public CreatePlanningGroupFactoryCommandHandler(IMapper mapper,
            IPlanningGroupFactoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePlanningGroupFactoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PlanningGroupFactory>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
