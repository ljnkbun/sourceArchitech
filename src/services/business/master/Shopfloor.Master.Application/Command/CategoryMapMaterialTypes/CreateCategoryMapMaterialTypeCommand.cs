using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CategoryMapMaterialTypes
{
    public class CreateCategoryMapMaterialTypeCommand : IRequest<Response<int>>
    {
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
    }
    public class CreateCategoryMapMaterialTypeCommandHandler : IRequestHandler<CreateCategoryMapMaterialTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryMapMaterialTypeRepository _repository;
        public CreateCategoryMapMaterialTypeCommandHandler(IMapper mapper,
            ICategoryMapMaterialTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryMapMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryMapMaterialType>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
