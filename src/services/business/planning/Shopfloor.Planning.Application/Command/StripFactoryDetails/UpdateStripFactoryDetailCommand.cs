using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactoryDetails
{
    public class UpdateStripFactoryDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int PorDetailId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int StripFactoryId { get; set; }
    }

    public class UpdateStripFactoryDetailCommandHandler : IRequestHandler<UpdateStripFactoryDetailCommand, Response<int>>
    {
        private readonly IStripFactoryRepository _factoryRepository;
        private readonly IStripFactoryDetailRepository _repository;

        public UpdateStripFactoryDetailCommandHandler(IStripFactoryRepository factoryRepository
            , IStripFactoryDetailRepository repository)
        {
            _factoryRepository = factoryRepository;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateStripFactoryDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new("StripFactoryDetail Not Found.");

            entity.PorDetailId = command.PorDetailId;
            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.Quantity = command.Quantity;
            entity.RemainingQuantity = command.RemainingQuantity;
            entity.TypePORDetail = command.TypePORDetail;
            entity.UOM = command.UOM;
            entity.StripFactoryId = command.StripFactoryId;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
