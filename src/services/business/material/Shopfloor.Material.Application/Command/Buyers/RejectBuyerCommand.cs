using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class RejectBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string ReasonReject { get; set; }
    }

    public class RejectBuyerCommandHandler : IRequestHandler<RejectBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public RejectBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(RejectBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"{typeof(Buyer).Name} Not Found (Id:{command.Id}).");
            entity.Status = Domain.Enums.ProcessStatus.Rejected;
            entity.ReasonReject = command.ReasonReject;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}