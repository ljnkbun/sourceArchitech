using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatures
{
    public class DeleteSewingFeatureCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingFeatureCommandHandler : IRequestHandler<DeleteSewingFeatureCommand, Response<int>>
    {
        private readonly ISewingFeatureRepository _repository;
        public DeleteSewingFeatureCommandHandler(ISewingFeatureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingFeatureCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"SewingFeature Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
