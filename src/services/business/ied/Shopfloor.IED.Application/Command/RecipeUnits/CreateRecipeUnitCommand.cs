using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeUnits
{
    public class CreateRecipeUnitCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateRecipeUnitCommandHandler : IRequestHandler<CreateRecipeUnitCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeUnitRepository _repository;
        public CreateRecipeUnitCommandHandler(IMapper mapper,
            IRecipeUnitRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RecipeUnit>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
