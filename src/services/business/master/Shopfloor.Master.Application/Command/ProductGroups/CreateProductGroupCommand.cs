using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class CreateProductGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public ICollection<CreateMaterialTypeMapProductGroupCommand> MaterialTypeMapProductGroups { get; set; }

    }
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _repository;
        public CreateProductGroupCommandHandler(IMapper mapper,
            IProductGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductGroup>(request);
            foreach (var item in entity.MaterialTypeMapProductGroups)
            {
                item.MaterialTypeId = entity.MaterialTypeId;
            }
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
