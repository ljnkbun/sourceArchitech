using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FPPODetails
{
    public class UpdateFPPODetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int FPPOId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
    }
    public class UpdateFPPODetailCommandHandler : IRequestHandler<UpdateFPPODetailCommand, Response<int>>
    {
        private readonly IFPPODetailRepository _repository;
        public UpdateFPPODetailCommandHandler(IFPPODetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFPPODetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FPPODetail Not Found.");

            entity.FPPOId = command.FPPOId;
            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.Quantity = command.Quantity;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
