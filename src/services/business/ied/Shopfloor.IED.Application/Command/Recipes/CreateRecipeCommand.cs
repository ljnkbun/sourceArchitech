using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RecipeTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Recipes
{
    public class CreateRecipeCommand : IRequest<Response<int>>
    {
        public int DyeingTBRecipeId { get; set; }

        public DateTime JobDate { get; set; }

        public string TCFNO { get; set; }

        public string Style { get; set; }

        public string Description { get; set; }

        public string FabricCode { get; set; }

        public string FabricName { get; set; }

        public string Color { get; set; }

        public string LotNo { get; set; }

        public string RollKg { get; set; }

        public string Speed { get; set; }

        public string NozzleA { get; set; }

        public string NozzleB { get; set; }

        public string Method { get; set; }

        public string LAB { get; set; }

        public string InCharge { get; set; }

        public string Manager { get; set; }

        public ICollection<CreateRecipeTaskCommand> RecipeTask { get; set; }
    }

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _repository;

        public CreateRecipeCommandHandler(IMapper mapper,
            IRecipeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Recipe>(request);
            await _repository.AddRecipeAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}