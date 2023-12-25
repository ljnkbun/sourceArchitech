using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SupplierTypes
{
    public class CreateSupplierTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateSupplierTypeCommandHandler : IRequestHandler<CreateSupplierTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierTypeRepository _repository;
        public CreateSupplierTypeCommandHandler(IMapper mapper,
            ISupplierTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSupplierTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SupplierType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
