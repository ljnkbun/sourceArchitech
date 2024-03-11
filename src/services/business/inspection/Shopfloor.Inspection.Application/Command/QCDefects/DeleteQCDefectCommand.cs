using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Command.QCDefects
{
    public class DeleteQCDefectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteQCDefectCommandHandler : IRequestHandler<DeleteQCDefectCommand, Response<int>>
    {
        private readonly IQCDefectRepository _repository;
        public DeleteQCDefectCommandHandler(IQCDefectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteQCDefectCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new ($"QCDefect Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
