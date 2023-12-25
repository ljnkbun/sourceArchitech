using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Structures
{
    public class DeleteStructureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStructureCommandHandler : IRequestHandler<DeleteStructureCommand, Response<int>>
    {
        private readonly IStructureRepository _repository;
        public DeleteStructureCommandHandler(IStructureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStructureCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Structure Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
