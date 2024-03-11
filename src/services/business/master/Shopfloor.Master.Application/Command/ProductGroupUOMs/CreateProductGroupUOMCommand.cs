using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroupUOMs
{
    public class CreateProductGroupUOMCommand : IRequest<Response<int>>
    {
        public int UOMId { get; set; }
        public int ProductGroupId { get; set; }
    }

    public class CreateProductGroupUOMCommandHandler : IRequestHandler<CreateProductGroupUOMCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupUOMRepository _repository;

        public CreateProductGroupUOMCommandHandler(IMapper mapper,
            IProductGroupUOMRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductGroupUOMCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductGroupUOM>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}