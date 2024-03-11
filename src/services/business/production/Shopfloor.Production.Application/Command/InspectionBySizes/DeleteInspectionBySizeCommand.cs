using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.InspectionBySizes
{
    public class DeleteInspectionBySizeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteInspectionBySizeCommandHandler : IRequestHandler<DeleteInspectionBySizeCommand, Response<int>>
    {
        private readonly IInspectionBySizeRepository _repository;
        public DeleteInspectionBySizeCommandHandler(IInspectionBySizeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteInspectionBySizeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"InspectionBySize Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
