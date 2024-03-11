using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputDetails
{
    public class UpdateFPPOOutputDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
    public class UpdateFPPOOutputDetailCommandHandler : IRequestHandler<UpdateFPPOOutputDetailCommand, Response<int>>
    {
        private readonly IFPPOOutputDetailRepository _repository;
        public UpdateFPPOOutputDetailCommandHandler(IFPPOOutputDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFPPOOutputDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FPPOOutputDetail Not Found.");

            entity.FPPOOutputId = command.FPPOOutputId;
            entity.PlannedQty = command.PlannedQty;
            entity.BalanceQty = command.BalanceQty;
            entity.MadeQty = command.MadeQty;
            entity.Size = command.Size;
            entity.Color = command.Color;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
