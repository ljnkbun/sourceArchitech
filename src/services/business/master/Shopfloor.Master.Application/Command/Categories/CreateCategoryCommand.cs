using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Categories
{
    public class CreateCategoryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        public CreateCategoryCommandHandler(IMapper mapper,
            ICategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Category>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
