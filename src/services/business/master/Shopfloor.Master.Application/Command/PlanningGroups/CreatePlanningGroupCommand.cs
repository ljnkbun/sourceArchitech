using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.PlanningGroupFactories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroups
{
    public class CreatePlanningGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public int CalendarId { get; set; }
        public ICollection<CreatePlanningGroupFactoryCommand> PlanningGroupFactories { get; set; }
    }
    public class CreatePlanningGroupCommandHandler : IRequestHandler<CreatePlanningGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanningGroupRepository _repository;
        public CreatePlanningGroupCommandHandler(IMapper mapper,
            IPlanningGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePlanningGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PlanningGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
