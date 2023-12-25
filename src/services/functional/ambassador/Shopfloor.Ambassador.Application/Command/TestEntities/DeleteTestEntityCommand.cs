using MediatR;
using Shopfloor.Ambassador.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Command.TestEntities
{
    public class DeleteTestEntityCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTestEntityCommandHandler : IRequestHandler<DeleteTestEntityCommand, Response<int>>
    {
        private readonly ITestEntityRepository _repository;
        public DeleteTestEntityCommandHandler(ITestEntityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteTestEntityCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"TestEntity Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
