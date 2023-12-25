using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups
{
    public class CreateMaterialTypeMapProductGroupCommand : IRequest<Response<int>>
    {
        public int ProductGroupId { get; set; }
        public int MaterialTypeId { get; set; }
    }
    public class CreateMaterialTypeMapProductGroupCommandHandler : IRequestHandler<CreateMaterialTypeMapProductGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMaterialTypeMapProductGroupRepository _repository;
        public CreateMaterialTypeMapProductGroupCommandHandler(IMapper mapper,
            IMaterialTypeMapProductGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMaterialTypeMapProductGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MaterialTypeMapProductGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
