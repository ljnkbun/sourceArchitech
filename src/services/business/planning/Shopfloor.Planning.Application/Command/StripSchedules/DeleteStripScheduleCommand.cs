using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedules
{
    public class DeleteStripScheduleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripScheduleCommandHandler : IRequestHandler<DeleteStripScheduleCommand, Response<int>>
    {
        private readonly IStripScheduleRepository _repository;
        private readonly IStripFactoryScheduleRepository _stripFactoryScheduleRepository;
        public DeleteStripScheduleCommandHandler(IStripScheduleRepository repository, 
            IStripFactoryScheduleRepository stripFactoryScheduleRepository)
        {
            _repository = repository;
            _stripFactoryScheduleRepository = stripFactoryScheduleRepository;
        }
        public async Task<Response<int>> Handle(DeleteStripScheduleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsNo(command.Id);
            if (entity == null) return new($"StripSchedule Not Found (Id:{command.Id}).");

            var stripFactorySchedule = await _stripFactoryScheduleRepository.GetStripFactoryScheduleByScheduleId(command.Id);
            if (stripFactorySchedule == null) return new($"Cannot delete StripSchedule");

            await _repository.DeleteSplitBatchOrNotAsync(entity, stripFactorySchedule);
            return new Response<int>(entity.Id);
        }
    }
}
