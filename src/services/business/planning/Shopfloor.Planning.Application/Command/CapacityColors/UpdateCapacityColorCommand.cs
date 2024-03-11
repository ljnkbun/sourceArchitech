using MediatR;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.CapacityColors
{
    public class UpdateCapacityColorCommand : IRequest<Response<int>>
    {
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
        public int Id { get; set; }
       
        public bool IsActive { set; get; }
    }
    public class UpdateCapacityColorCommandHandler : IRequestHandler<UpdateCapacityColorCommand, Response<int>>
    {
        private readonly ICapacityColorRepository _repository;
        public UpdateCapacityColorCommandHandler(ICapacityColorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCapacityColorCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"CapacityColor Not Found.");
            entity.IsActive = command.IsActive;
            entity.Color = command.Color;
			entity.FromRange = command.FromRange;
			entity.ToRange = command.ToRange;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
