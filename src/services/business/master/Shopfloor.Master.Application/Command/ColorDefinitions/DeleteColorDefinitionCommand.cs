using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorDefinitions
{
    public class DeleteColorDefinitionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteColorDefinitionCommandHandler : IRequestHandler<DeleteColorDefinitionCommand, Response<int>>
    {
        private readonly IColorDefinitionRepository _repository;
        public DeleteColorDefinitionCommandHandler(IColorDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteColorDefinitionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"ColorDefinition Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
