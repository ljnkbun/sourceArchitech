using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PaymentTerms
{
    public class CreatePaymentTermCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditDays { get; set; }
    }
    public class CreatePaymentTermCommandHandler : IRequestHandler<CreatePaymentTermCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentTermRepository _repository;
        public CreatePaymentTermCommandHandler(IMapper mapper,
            IPaymentTermRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreatePaymentTermCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PaymentTerm>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
