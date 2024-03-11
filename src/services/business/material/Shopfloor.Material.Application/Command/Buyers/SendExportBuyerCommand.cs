using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class SendExportBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SendExportBuyerCommandHandler : IRequestHandler<SendExportBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public SendExportBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SendExportBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Buyer Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Exported;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}