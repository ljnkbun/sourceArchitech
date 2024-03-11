using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.FabricContents
{
    public class DeleteFabricContentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFabricContentCommandHandler : IRequestHandler<DeleteFabricContentCommand, Response<int>>
    {
        private readonly IFabricContentRepository _repository;
        public DeleteFabricContentCommandHandler(IFabricContentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFabricContentCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FabricContent Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
