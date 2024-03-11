using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripScheduleDetails
{
    public class UpdateStripScheduleDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripScheduleId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateStripScheduleDetailCommandHandler : IRequestHandler<UpdateStripScheduleDetailCommand, Response<int>>
    {
        private readonly IStripScheduleDetailRepository _repository;

        public UpdateStripScheduleDetailCommandHandler(IStripScheduleDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStripScheduleDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"StripScheduleDetail Not Found.");

            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.UOM = command.UOM;
            entity.Quantity = command.Quantity;
            entity.StripScheduleId = command.StripScheduleId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
