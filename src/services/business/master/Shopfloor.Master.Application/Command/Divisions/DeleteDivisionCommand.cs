using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Divisions
{
    public class DeleteDivisionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDivisionCommandHandler : IRequestHandler<DeleteDivisionCommand, Response<int>>
    {
        private readonly IDivisionRepository _repository;
        public DeleteDivisionCommandHandler(IDivisionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDivisionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Division Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
