using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMs
{
    public class UpdateUOMCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DecimalPlaces { get; set; }
        public int OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateUOMCommandHandler : IRequestHandler<UpdateUOMCommand, Response<int>>
    {
        private readonly IUOMRepository _repository;
        public UpdateUOMCommandHandler(IUOMRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateUOMCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"UOM Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.DecimalPlaces = command.DecimalPlaces;
            entity.OrderDecimalPlaces = command.OrderDecimalPlaces;
            entity.Action = command.Action;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
