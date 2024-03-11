using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class SoftDeleteBuyerByCodeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
    }

    public class DeleteBuyerByCodeCommandRequest : IRequestHandler<SoftDeleteBuyerByCodeCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public DeleteBuyerByCodeCommandRequest(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SoftDeleteBuyerByCodeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetBuyerByCodeAsync(command.Code);
            if (entity == null) return new($"{nameof(Buyer)} Not Found (Code:{command.Code}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}