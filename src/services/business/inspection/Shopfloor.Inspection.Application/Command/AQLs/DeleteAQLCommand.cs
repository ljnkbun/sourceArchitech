using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.AQLs
{
    public class DeleteAQLCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteAQLCommandHandler : IRequestHandler<DeleteAQLCommand, Response<int>>
    {
        private readonly IAQLRepository _repository;
        public DeleteAQLCommandHandler(IAQLRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteAQLCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"AQL Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
