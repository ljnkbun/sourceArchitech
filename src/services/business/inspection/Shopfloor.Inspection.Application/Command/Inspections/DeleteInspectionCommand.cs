using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Inspections
{
    public class DeleteInspectionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionCommandHandler : IRequestHandler<DeleteInspectionCommand, Response<int>>
    {
        private readonly IInspectionRepository _repository;
        public DeleteInspectionCommandHandler(IInspectionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Inspection Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
