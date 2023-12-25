using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class SendApproveMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SendApproveMaterialRequestCommandHandler : IRequestHandler<SendApproveMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repository;

        public SendApproveMaterialRequestCommandHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SendApproveMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"MaterialRequest Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Confirmed;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}