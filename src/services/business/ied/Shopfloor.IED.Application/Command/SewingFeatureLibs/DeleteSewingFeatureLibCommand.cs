using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatureLibs
{
    public class DeleteSewingFeatureLibCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingFeatureLibCommandHandler : IRequestHandler<DeleteSewingFeatureLibCommand, Response<int>>
    {
        private readonly ISewingFeatureLibRepository _repository;
        public DeleteSewingFeatureLibCommandHandler(ISewingFeatureLibRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingFeatureLibCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingFeatureLib Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
