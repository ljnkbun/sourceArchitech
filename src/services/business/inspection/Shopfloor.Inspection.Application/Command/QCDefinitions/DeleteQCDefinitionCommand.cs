using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCDefinitions
{
    public class DeleteQCDefinitionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCDefinitionCommandHandler : IRequestHandler<DeleteQCDefinitionCommand, Response<int>>
    {
        private readonly IQCDefinitionRepository _repository;
        public DeleteQCDefinitionCommandHandler(IQCDefinitionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCDefinitionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"QCDefinition Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
