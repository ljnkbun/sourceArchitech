using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionProcesses
{
    public class DeleteRequestDivisionProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRequestDivisionProcessCommandHandler : IRequestHandler<DeleteRequestDivisionProcessCommand, Response<int>>
    {
        private readonly IRequestDivisionProcessRepository _repository;
        public DeleteRequestDivisionProcessCommandHandler(IRequestDivisionProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRequestDivisionProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"RequestDivisionProcess Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
