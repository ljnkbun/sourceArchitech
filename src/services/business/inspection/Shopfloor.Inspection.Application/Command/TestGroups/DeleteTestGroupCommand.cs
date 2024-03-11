using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.TestGroups
{
    public class DeleteTestGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTestGroupCommandHandler : IRequestHandler<DeleteTestGroupCommand, Response<int>>
    {
        private readonly ITestGroupRepository _repository;
        public DeleteTestGroupCommandHandler(ITestGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteTestGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"TestGroup Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
