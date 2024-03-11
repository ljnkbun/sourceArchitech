using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingDetailStructures
{
    public class DeleteWeavingDetailStructureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingDetailStructureCommandHandler : IRequestHandler<DeleteWeavingDetailStructureCommand, Response<int>>
    {
        private readonly IWeavingDetailStructureRepository _repository;
        public DeleteWeavingDetailStructureCommandHandler(IWeavingDetailStructureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingDetailStructureCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingDetailStructure Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
