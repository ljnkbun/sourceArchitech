using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMatrics
{
    public class DeleteWeavingRappoMatricCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingRappoMatricCommandHandler : IRequestHandler<DeleteWeavingRappoMatricCommand, Response<int>>
    {
        private readonly IWeavingRappoMatricRepository _repository;
        public DeleteWeavingRappoMatricCommandHandler(IWeavingRappoMatricRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingRappoMatricCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"WeavingRappoMatric Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
