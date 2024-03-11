using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefectTypes
{
    public class DeleteQCDefectTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCDefectTypeCommandHandler : IRequestHandler<DeleteQCDefectTypeCommand, Response<int>>
    {
        private readonly IQCDefectTypeRepository _repository;
        public DeleteQCDefectTypeCommandHandler(IQCDefectTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCDefectTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"QCDefectType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
