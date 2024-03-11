using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.PlanningGroupFactories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PlanningGroups
{
    public class UpdatePlanningGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public int CalendarId { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdatePlanningGroupFactoryCommand> PlanningGroupFactories { get; set; }
    }
    public class UpdatePlanningGroupCommandHandler : IRequestHandler<UpdatePlanningGroupCommand, Response<int>>
    {
        private readonly IPlanningGroupRepository _repository;
        private readonly IMapper _mapper;
        public UpdatePlanningGroupCommandHandler(IPlanningGroupRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdatePlanningGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"PlanningGroup Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.ProcessId = command.ProcessId;
            entity.CalendarId = command.CalendarId;
            entity.IsActive = command.IsActive;

            entity.PlanningGroupFactories = _mapper.Map<ICollection<PlanningGroupFactory>>(command.PlanningGroupFactories);

            await _repository.UpdatePlanningGroupFactoryAsync(entity, entity.PlanningGroupFactories);

            return new Response<int>(entity.Id);
        }
    }
}
