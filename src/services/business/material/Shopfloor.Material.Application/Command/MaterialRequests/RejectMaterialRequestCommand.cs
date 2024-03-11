using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class RejectMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string ReasonReject { get; set; }
    }

    public class RejectMaterialRequestCommandHandler : IRequestHandler<RejectMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repository;

        public RejectMaterialRequestCommandHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(RejectMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"MaterialRequest Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Rejected;
            entity.ReasonReject = command.ReasonReject;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}