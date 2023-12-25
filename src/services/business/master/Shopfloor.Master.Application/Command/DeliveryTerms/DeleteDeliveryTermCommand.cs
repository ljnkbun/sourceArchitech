using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.DeliveryTerms
{
    public class DeleteDeliveryTermCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDeliveryTermCommandHandler : IRequestHandler<DeleteDeliveryTermCommand, Response<int>>
    {
        private readonly IDeliveryTermRepository _repository;
        public DeleteDeliveryTermCommandHandler(IDeliveryTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDeliveryTermCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DeliveryTerm Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
