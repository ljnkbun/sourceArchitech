using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs
{
    public class DeleteWeavingRusticFabricSpecCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingRusticFabricSpecCommandHandler : IRequestHandler<DeleteWeavingRusticFabricSpecCommand, Response<int>>
    {
        private readonly IWeavingRusticFabricSpecRepository _repository;
        public DeleteWeavingRusticFabricSpecCommandHandler(IWeavingRusticFabricSpecRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingRusticFabricSpecCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"WeavingRusticFabricSpec Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
