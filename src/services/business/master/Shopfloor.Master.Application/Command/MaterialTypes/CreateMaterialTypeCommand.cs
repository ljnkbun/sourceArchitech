using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypes
{
    public class CreateMaterialTypeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ICollection<CreateCategoryMapMaterialTypeCommand> CategoryMapMaterialTypes { get; set; }
    }
    public class CreateMaterialTypeCommandHandler : IRequestHandler<CreateMaterialTypeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeRepository _repository;
        public CreateMaterialTypeCommandHandler(IMapper mapper,
            IMaterialTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaterialTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialType>(request);
            foreach (var item in entity.CategoryMapMaterialTypes)
            {
                item.CategoryId = entity.CategoryId;
            }
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
