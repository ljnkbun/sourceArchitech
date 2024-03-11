using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Tests
{
    public class DeleteTestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, Response<int>>
    {
        private readonly ITestRepository _repository;
        public DeleteTestCommandHandler(ITestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteTestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Test Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
