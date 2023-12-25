using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Factories
{
    public class DeleteFactoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFactoryCommandHandler : IRequestHandler<DeleteFactoryCommand, Response<int>>
    {
        private readonly IFactoryRepository _repository;
        public DeleteFactoryCommandHandler(IFactoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFactoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Factory Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
