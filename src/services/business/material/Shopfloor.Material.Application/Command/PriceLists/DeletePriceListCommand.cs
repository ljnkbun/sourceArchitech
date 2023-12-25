using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.PriceLists
{
    public class DeletePriceListCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePriceListCommandHandler : IRequestHandler<DeletePriceListCommand, Response<int>>
    {
        private readonly IPriceListRepository _repository;

        public DeletePriceListCommandHandler(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeletePriceListCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"PriceList Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}