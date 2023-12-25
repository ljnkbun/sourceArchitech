using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.GroupNames
{
    public class DeleteGroupNameCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteGroupNameCommandHandler : IRequestHandler<DeleteGroupNameCommand, Response<int>>
    {
        private readonly IGroupNameRepository _repository;
        public DeleteGroupNameCommandHandler(IGroupNameRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteGroupNameCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"GroupName Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
