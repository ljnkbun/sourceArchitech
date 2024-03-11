using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactorySchedules
{
    public class DeleteStripFactoryScheduleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripFactoryScheduleCommandHandler : IRequestHandler<DeleteStripFactoryScheduleCommand, Response<int>>
    {
        private readonly IStripFactoryScheduleRepository _repository;
        public DeleteStripFactoryScheduleCommandHandler(IStripFactoryScheduleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStripFactoryScheduleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetStripFactoryScheduleInculeById(command.Id);
            if (entity == null) return new($"StripFactorySchedule Not Found (Id:{command.Id}).");
            if (entity.StripScheduleId != null) return new($"Cannot Delete Because It's Planned (Id:{command.Id}).");
            if (entity.BatchNo == null) return new($"BatchNo Not Found (Id:{command.Id}).");

            await _repository.DeleteStripFactorySchedule(entity);
            return new Response<int>(entity.Id);
        }
    }
}
