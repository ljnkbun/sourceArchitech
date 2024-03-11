using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactorySchedules
{
    public class UpdateStripFactoryScheduleCommand : IRequest<Response<int>>
    {
        public int StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }
        public int Id { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateStripFactoryScheduleCommandHandler : IRequestHandler<UpdateStripFactoryScheduleCommand, Response<int>>
    {
        private readonly IStripFactoryScheduleRepository _repository;
        public UpdateStripFactoryScheduleCommandHandler(IStripFactoryScheduleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStripFactoryScheduleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripFactorySchedule Not Found.");
            entity.IsActive = command.IsActive;
            entity.StripFactoryId = command.StripFactoryId;
            entity.StripScheduleId = command.StripScheduleId;
            entity.Quantity = command.Quantity;
            entity.BatchNo = command.BatchNo;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
