using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingComponents
{
    public class DeleteSewingComponentCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingComponentCommandHandler : IRequestHandler<DeleteSewingComponentCommand, Response<int>>
    {
        private readonly ISewingComponentRepository _repository;
        public DeleteSewingComponentCommandHandler(ISewingComponentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingComponentCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingComponent Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
