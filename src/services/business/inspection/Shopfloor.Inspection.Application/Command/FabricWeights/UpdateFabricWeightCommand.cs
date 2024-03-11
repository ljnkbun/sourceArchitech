using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.FabricWeights
{
    public class UpdateFabricWeightCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public bool IsActive { set; get; }
    }
    public class UpdateFabricWeightCommandHandler : IRequestHandler<UpdateFabricWeightCommand, Response<int>>
    {
        private readonly IFabricWeightRepository _repository;
        public UpdateFabricWeightCommandHandler(IFabricWeightRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFabricWeightCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FabricWeight Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
