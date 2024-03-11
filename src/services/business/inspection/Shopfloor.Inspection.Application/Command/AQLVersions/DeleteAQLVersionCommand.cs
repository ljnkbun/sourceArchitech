using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.AQLVersions
{
    public class DeleteAQLVersionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteAQLVersionCommandHandler : IRequestHandler<DeleteAQLVersionCommand, Response<int>>
    {
        private readonly IAQLVersionRepository _repository;
        public DeleteAQLVersionCommandHandler(IAQLVersionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteAQLVersionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"AQLVersion Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
