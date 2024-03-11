using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactoryScheduleDetails
{
    public class UpdateStripFactoryScheduleDetailCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripFactoryScheduleId { get; set; }
        public int Id { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateStripFactoryScheduleDetailCommandHandler : IRequestHandler<UpdateStripFactoryScheduleDetailCommand, Response<int>>
    {
        private readonly IStripFactoryScheduleDetailRepository _repository;
        public UpdateStripFactoryScheduleDetailCommandHandler(IStripFactoryScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStripFactoryScheduleDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripFactoryScheduleDetail Not Found.");

            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.UOM = command.UOM;
            entity.Quantity = command.Quantity;
            entity.StripFactoryScheduleId = command.StripFactoryScheduleId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
