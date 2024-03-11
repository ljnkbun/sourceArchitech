using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactories
{
    public class DeleteStripFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteStripFactoryCommandHandler : IRequestHandler<DeleteStripFactoryCommand, Response<int>>
    {
        private readonly IStripFactoryRepository _repository;
        public DeleteStripFactoryCommandHandler(IStripFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteStripFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"StripFactory Not Found (Id:{command.Id}).");
            if (entity.IsAllocated == true) return new($"StripFactory Is Allocated, Cannot delete (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
