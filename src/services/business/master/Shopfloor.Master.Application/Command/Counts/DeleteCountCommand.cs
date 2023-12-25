using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Counts
{
    public class DeleteCountCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCountCommandHandler : IRequestHandler<DeleteCountCommand, Response<int>>
    {
        private readonly ICountRepository _repository;
        public DeleteCountCommandHandler(ICountRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCountCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Count Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
