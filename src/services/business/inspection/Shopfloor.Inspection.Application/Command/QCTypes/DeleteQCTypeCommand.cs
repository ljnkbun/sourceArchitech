using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.QCTypes
{
    public class DeleteQCTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCTypeCommandHandler : IRequestHandler<DeleteQCTypeCommand, Response<int>>
    {
        private readonly IQCTypeRepository _repository;
        public DeleteQCTypeCommandHandler(IQCTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"QCType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
