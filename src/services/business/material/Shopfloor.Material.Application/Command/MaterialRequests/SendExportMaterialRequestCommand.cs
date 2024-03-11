using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequests
{
    public class SendExportMaterialRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SendExportMaterialRequestCommandHandler : IRequestHandler<SendExportMaterialRequestCommand, Response<int>>
    {
        private readonly IMaterialRequestRepository _repository;

        public SendExportMaterialRequestCommandHandler(IMaterialRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SendExportMaterialRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"MaterialRequest Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Exported;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}