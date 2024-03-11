using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefinitionDefects
{
    public class DeleteQCDefinitionDefectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCDefinitionDefectCommandHandler : IRequestHandler<DeleteQCDefinitionDefectCommand, Response<int>>
    {
        private readonly IQCDefinitionDefectRepository _repository;
        public DeleteQCDefinitionDefectCommandHandler(IQCDefinitionDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCDefinitionDefectCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"QCDefinitionDefect Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
