using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Enums;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class RejectPriceListCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public string ReasonReject { get; set; }
    }

    public class RejectPriceListCommandHandler : IRequestHandler<RejectPriceListCommand, Response<int>>
    {
        private readonly IPriceListRepository _repository;

        public RejectPriceListCommandHandler(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(RejectPriceListCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"PriceList Not Found (Id:{command.Id}).");
            entity.Status = ProcessStatus.Rejected;
            entity.ReasonReject = command.ReasonReject;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}