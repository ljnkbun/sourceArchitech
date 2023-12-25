using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class ApproveMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class ApproveMaterialRequestCommandHandler : IRequestHandler<ApproveMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repository;

        public ApproveMaterialRequestCommandHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(ApproveMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"MaterialRequest Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Approved;
            entity.ReasonReject = null;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}