using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.RecipeChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RecipeTasks
{
    public class CreateRecipeTaskCommand : IRequest<Response<int>>
    {
        public int RecipeId { get; set; }

        public string DyeingOpreation { get; set; }

        public string MachineType { get; set; }

        public int Minutes { get; set; }

        public decimal Temperature { get; set; }

        public ICollection<CreateRecipeChemicalCommand> RecipeChemical { get; set; }
    }

    public class CreateRecipeTaskCommandHandler : IRequestHandler<CreateRecipeTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRecipeTaskRepository _repository;

        public CreateRecipeTaskCommandHandler(IMapper mapper,
            IRecipeTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRecipeTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.RecipeTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}