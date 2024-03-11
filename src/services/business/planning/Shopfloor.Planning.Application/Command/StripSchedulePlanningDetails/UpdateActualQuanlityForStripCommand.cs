using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails
{
    public class UpdateActualQuanlityForStripCommand : IRequest<Response<bool>>
    {
        public int FPPOId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
    }
    public class UpdateActualQuanlityForStripCommandHandler : IRequestHandler<UpdateActualQuanlityForStripCommand, Response<bool>>
    {
        private readonly IStripSchedulePlanningDetailRepository _repository;

        public UpdateActualQuanlityForStripCommandHandler(IStripSchedulePlanningDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(UpdateActualQuanlityForStripCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByFPPOIdAsync(command.FPPOId, command.Date);

            if (entity == null) return new($"StripSchedulePlanningDetail Not Found.");

            entity.ReceivedCapacity = entity.ReceivedCapacity + command.Quantity;

            await _repository.UpdateAsync(entity);
            return new Response<bool>(true);
        }
    }
}
