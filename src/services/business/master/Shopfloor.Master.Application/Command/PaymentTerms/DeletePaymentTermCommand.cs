using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PaymentTerms
{
    public class DeletePaymentTermCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePaymentTermCommandHandler : IRequestHandler<DeletePaymentTermCommand, Response<int>>
    {
        private readonly IPaymentTermRepository _repository;
        public DeletePaymentTermCommandHandler(IPaymentTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeletePaymentTermCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"PaymentTerm Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
