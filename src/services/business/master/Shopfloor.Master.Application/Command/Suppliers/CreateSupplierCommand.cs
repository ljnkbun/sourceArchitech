using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Suppliers
{
    public class CreateSupplierCommand : IRequest<Response<int>>
    {
        public string WFXSupplierId { get; set; }
        public string Name { get; set; }
    }

    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _repository;

        public CreateSupplierCommandHandler(IMapper mapper,
            ISupplierRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Supplier>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}