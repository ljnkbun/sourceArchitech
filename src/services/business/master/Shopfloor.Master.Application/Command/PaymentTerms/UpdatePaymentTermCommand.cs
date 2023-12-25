using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PaymentTerms
{
    public class UpdatePaymentTermCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditDays { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdatePaymentTermCommandHandler : IRequestHandler<UpdatePaymentTermCommand, Response<int>>
    {
        private readonly IPaymentTermRepository _repository;
        public UpdatePaymentTermCommandHandler(IPaymentTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdatePaymentTermCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"PaymentTerms Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CreditDays = command.CreditDays;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
