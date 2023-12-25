using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubCategoryGroups
{
    public class CreateSubCategoryGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    public class CreateSubCategoryGroupCommandHandler : IRequestHandler<CreateSubCategoryGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryGroupRepository _repository;
        public CreateSubCategoryGroupCommandHandler(IMapper mapper,
            ISubCategoryGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSubCategoryGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SubCategoryGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
