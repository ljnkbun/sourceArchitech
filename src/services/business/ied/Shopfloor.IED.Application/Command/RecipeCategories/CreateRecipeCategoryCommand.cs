using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeCategories
{
    public class CreateRecipeCategoryCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateRecipeCategoryCommandHandler : IRequestHandler<CreateRecipeCategoryCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeCategoryRepository _repository;
        public CreateRecipeCategoryCommandHandler(IMapper mapper,
            IRecipeCategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RecipeCategory>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
