using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FabricWidths
{
    public class UpdateFabricWidthCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFabricWidthCommandHandler : IRequestHandler<UpdateFabricWidthCommand, Response<int>>
    {
        private readonly IFabricWidthRepository _repository;
        public UpdateFabricWidthCommandHandler(IFabricWidthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFabricWidthCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"FabricWidth Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.SortOrder = command.SortOrder;
            entity.Inseam = command.Inseam;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
