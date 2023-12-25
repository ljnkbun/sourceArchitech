using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Constructions
{
    public class DeleteConstructionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteConstructionCommandHandler : IRequestHandler<DeleteConstructionCommand, Response<int>>
    {
        private readonly IConstructionRepository _repository;
        public DeleteConstructionCommandHandler(IConstructionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteConstructionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Construction Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
